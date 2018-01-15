using ExampleApplication.Model.Utils;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.ListBoxItems;
using ExampleApplication.Resources.AutomationIdentifiers;
using ExampleApplication.Resources;

namespace ExampleApplication.Model
{
    public class MainWindowModel
    {
        private Window window;

        public MainWindowModel(Window window)
        {
            this.window = window;
        }

        private Button add;

        public Button Add
        {
            get
            {
                return window.GetLazyProperty(ref add, string.Format(MainWindowIds.CommandButton, Resource.Command_Add_Name));
            }
        }

        private Button remove;

        public Button Remove
        {
            get
            {
                return window.GetLazyProperty(ref remove, string.Format(MainWindowIds.CommandButton, Resource.Command_Remove_Name));
            }
        }

        private Button close;

        public Button Close
        {
            get
            {
                return window.GetLazyProperty(ref close, MainWindowIds.CloseButton);
            }
        }

        private PersonListModel peoplelist;

        public PersonListModel PersonList
        {
            get
            {
                return window.GetLazyProperty(ref peoplelist, MainWindowIds.ListBox, (ListBox listBox) => new PersonListModel(listBox));
            }
        }



        private ApplicationMenuModel menus;

        public ApplicationMenuModel Menu
        {
            get
            {
                return window.GetLazyProperty(ref menus, MainWindowIds.ApplicationMenu, (UIItem menu) => new ApplicationMenuModel(menu));
            }
        }

        private TextBox firstname;

        public TextBox FirstName
        {
            get
            {
                return window.GetLazyProperty(ref firstname, MainWindowIds.FirstNameTextBox);
            }
        }

        private TextBox lastname;

        public TextBox LastName
        {
            get
            {
                return window.GetLazyProperty(ref lastname, MainWindowIds.LastNameTextBox);
            }
        }

        private TextBox description;

        public TextBox Description
        {
            get
            {
                return window.GetLazyProperty(ref description, MainWindowIds.DescriptionTextBox);
            }
        }
    }
}
