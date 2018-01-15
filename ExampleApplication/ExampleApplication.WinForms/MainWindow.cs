using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;
using ExampleApplication.Logic;

namespace ExampleApplication.WinForms
{
    public partial class MainWindow : Form
    {
        private PersonsViewModel persons;
        
        public MainWindow()
        {
            InitializeComponent();
            persons = new PersonsViewModel();
            RefreshMenu();
            RefreshListBox();

            persons.SelectedItemChanged += Persons_SelectedItemChanged;
            ((INotifyCollectionChanged)persons.Items).CollectionChanged += PersonsItems_CollectionChanged;
            persons.AddCommand.CanExecuteChanged += AddCommand_CanExecuteChanged;
            persons.RemoveCommand.CanExecuteChanged += RemoveCommand_CanExecuteChanged;
        }

        private void RefreshMenu()
        {
            foreach (var item in ItemsMenuItem.DropDown.Items)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem) item;
                menuItem.QueryAccessibilityHelp -= ItemsMenuItem_QueryAccessibilityHelp;
            }

            ItemsMenuItem.DropDown.Items.Clear();

            foreach (PersonViewModel person in persons.Items)
            {
                ItemsMenuItem.DropDown.Items.Add(person.WholeName).QueryAccessibilityHelp += ItemsMenuItem_QueryAccessibilityHelp;
            }
        }

        private void RefreshListBox()
        {
            ListBox.Items.Clear();
            foreach (PersonViewModel person in persons.Items)
            {
                ListBox.Items.Add(person.WholeName);
            }
        }
        private void UpdatePersonDetail()
        {
            bool detailIsVisible = persons.SelectedItem != null;

            if (detailIsVisible)
            {
                TextBox_FirstName.Text = persons.SelectedItem.FirstName;
                TextBox_LastName.Text = persons.SelectedItem.LastName;
                TextBox_Description.Text = persons.SelectedItem.Description;
            }

            TextBox_FirstName.Visible = detailIsVisible;
            TextBox_LastName.Visible = detailIsVisible;
            TextBox_Description.Visible = detailIsVisible;

            Label_FirstName.Visible = detailIsVisible;
            Label_LastName.Visible = detailIsVisible;
            Label_Description.Visible = detailIsVisible;
        }

        private void DeregisterSelectedItemEvents(PersonViewModel selectedItem)
        {
            selectedItem.FirstNameChanged -= SelectedItem_FirstNameChanged;
            selectedItem.LastNameChanged -= SelectedItem_LastNameChanged;
            selectedItem.WholeNameChanged -= SelectedItem_WholeNameChanged;
        }

        private void RegisterSelectedItemEvents(PersonViewModel selectedItem)
        {
            selectedItem.FirstNameChanged += SelectedItem_FirstNameChanged;
            selectedItem.LastNameChanged += SelectedItem_LastNameChanged;
            selectedItem.WholeNameChanged += SelectedItem_WholeNameChanged;
            selectedItem.DescriptionChanged += SelectedItem_DescriptionChanged;
        }

        private void UpdateSelectedMenuItem()
        {
            int index = 0;
            foreach (object item in ItemsMenuItem.DropDown.Items)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)item;
                menuItem.Checked = persons.SelectedIndex == index;
                index++;
            }
        }

        #region viewModel events

        private void AddCommand_CanExecuteChanged(object sender, EventArgs e)
        {
            addToolStripMenuItem.Enabled = persons.AddCommand.CanExecute(null);
            Button_Add.Enabled = persons.AddCommand.CanExecute(null);
        }

        private void RemoveCommand_CanExecuteChanged(object sender, EventArgs e)
        {
            removeToolStripMenuItem.Enabled = persons.RemoveCommand.CanExecute(null);
            Button_Remove.Enabled = persons.RemoveCommand.CanExecute(null);
        }

        private void PersonsItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        // we suppose, only one item will be added
                        ListBox.Items.Insert(e.NewStartingIndex, ((PersonViewModel)e.NewItems[0]).WholeName);

                        var menuItem = new ToolStripMenuItem(((PersonViewModel)e.NewItems[0]).WholeName);
                        ((IList)ItemsMenuItem.DropDown.Items).Insert(e.NewStartingIndex, menuItem);
                        menuItem.QueryAccessibilityHelp += ItemsMenuItem_QueryAccessibilityHelp;
                        break;
                    }

                case NotifyCollectionChangedAction.Remove:
                    {
                        // we suppose only one item will be added
                        ListBox.Items.RemoveAt(e.OldStartingIndex);
                        var menuItem = ItemsMenuItem.DropDown.Items[e.OldStartingIndex];
                        ItemsMenuItem.DropDown.Items.Remove(menuItem);
                        menuItem.QueryAccessibilityHelp -= ItemsMenuItem_QueryAccessibilityHelp;
                        break;
                    }

                case NotifyCollectionChangedAction.Reset:
                    {
                        RefreshListBox();
                        RefreshMenu();
                        break;
                    }
            }
        }

        private void Persons_SelectedItemChanged(object sender, ValueChangedEventArgs<PersonViewModel> e)
        {
            if (e.OldValue != null)
            {
                DeregisterSelectedItemEvents(e.OldValue);
            }

            UpdatePersonDetail();
            UpdateSelectedMenuItem();
            ListBox.SelectedIndex = persons.SelectedIndex;

            if (e.NewValue != null)
            {
                RegisterSelectedItemEvents(e.NewValue);
            }
        }

        private void SelectedItem_DescriptionChanged(object sender, EventArgs e)
        {
            TextBox_Description.Text = persons.SelectedItem.Description;
        }

        private void SelectedItem_WholeNameChanged(object sender, EventArgs e)
        {
            // we should react to any PersonViewModel.WholeName change, but for simplicity we suppose that only selected person is updated
            ListBox.Items[persons.SelectedIndex] = persons.SelectedItem.WholeName;
            ItemsMenuItem.DropDown.Items[persons.SelectedIndex].Text = persons.SelectedItem.WholeName;
        }

        private void SelectedItem_LastNameChanged(object sender, EventArgs e)
        {
            TextBox_LastName.Text = persons.SelectedItem.LastName;
        }

        private void SelectedItem_FirstNameChanged(object sender, EventArgs e)
        {
            TextBox_FirstName.Text = persons.SelectedItem.FirstName;
        }

        private void FirstName_TextChanged(object sender, EventArgs e)
        {
            if (persons.SelectedItem == null)
            {
                return;
            }

            persons.SelectedItem.FirstName = TextBox_FirstName.Text;
        }

        private void LastName_TextChanged(object sender, EventArgs e)
        {
            if (persons.SelectedItem == null)
            {
                return;
            }

            persons.SelectedItem.LastName = TextBox_LastName.Text;
        }

        private void Description_TextChanged(object sender, EventArgs e)
        {
            if (persons.SelectedItem == null)
            {
                return;
            }

            persons.SelectedItem.Description = TextBox_Description.Text;
        }

        #endregion

        #region view events

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ListBox.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            persons.SelectedItem = persons.Items.ElementAt(index);
        }

        private void Add_Button_MouseClick(object sender, MouseEventArgs e)
        {
            persons.AddCommand.Execute(null);
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            persons.AddCommand.Execute(null);
        }
        private void Remove_Button_MouseClick(object sender, MouseEventArgs e)
        {
            persons.RemoveCommand.Execute(null);
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            persons.RemoveCommand.Execute(null);
        }
        private void Items_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int index = ItemsMenuItem.DropDown.Items.IndexOf(e.ClickedItem);
            persons.SelectedItem = persons.Items.ElementAt(index);
        }

        private void ItemsMenuItem_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem == null)
            {
                return;
            }

            int index = ItemsMenuItem.DropDown.Items.IndexOf(menuItem);
            e.HelpString = (persons.SelectedItem != null && persons.SelectedIndex == index).ToString();
        }

        #endregion
    }
}
