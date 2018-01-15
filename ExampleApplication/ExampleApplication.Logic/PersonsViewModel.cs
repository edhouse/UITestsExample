using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ExampleApplication.Resources;

namespace ExampleApplication.Logic
{
    public class PersonsViewModel : ViewModelBase
    {
        private ObservableCollection<PersonViewModel> items;
        private ReadOnlyObservableCollection<PersonViewModel> readonlyItems;
        private PersonViewModel selectedItem;

        public PersonsViewModel()
        {
            AddCommand = new Command(Resource.Command_Add_Name, Resource.Command_Add_Description,
                o => CreateItem());
            RemoveCommand = new Command(Resource.Command_Remove_Name, Resource.Command_Remove_Description,
                o => RemoveSelectedItem(), o => SelectedItem != null);
            SelectCommand = new Command(o => SelectItem(o as PersonViewModel));
            items = new ObservableCollection<PersonViewModel>();
            readonlyItems = new ReadOnlyObservableCollection<PersonViewModel>(items);

            items.Add(new PersonViewModel("Paulo", "Coelho", "Brazilian lyricist and novelist." ));
            items.Add(new PersonViewModel("Mikhail", "Bulgakov",
                "Russian writer and playwright active in the first half of the 20th century."));
        }

        public event EventHandler<ValueChangedEventArgs<PersonViewModel>> SelectedItemChanged;

        public PersonViewModel SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(nameof(SelectedItem), ref selectedItem, value, OnSelectedItemChanged); }
        }

        public int SelectedIndex
        {
            get { return items.IndexOf(SelectedItem); }
        }

        public ReadOnlyObservableCollection<PersonViewModel> Items
        {
            get { return readonlyItems; }
        }

        public IEnumerable<Command> Commands
        {
            get
            {
                yield return AddCommand;
                yield return RemoveCommand;
            }
        }

        public Command AddCommand { get; }
        public Command RemoveCommand { get; }
        public Command SelectCommand { get; }

        public void SelectItem(PersonViewModel person)
        {
            SelectedItem = person;
        }

        // Creates new item with default values or creates copy of currently selected item. Newly created item is selected.
        public void CreateItem()
        {
            PersonViewModel person = null;
            if (SelectedItem != null)
            {
                person = (PersonViewModel)SelectedItem.Clone();
                person.LastName += " Copy";
            }
            else
            {
                person = new PersonViewModel(
                    Resource.NewPerson_FirstName,
                    Resource.NewPerson_LastName,
                    Resource.NewPerson_Description);
            }

            items.Add(person);
            SelectedItem = person;
        }

        // Removes selected item and selects next if it is possible
        public void RemoveSelectedItem()
        {
            int index = SelectedIndex;
            items.Remove(SelectedItem);
            if (index < items.Count)
            {
                SelectedItem = items.ElementAt(index);
            }
        }

        private void OnSelectedItemChanged(ValueChangedEventArgs<PersonViewModel> args)
        {
            FireSelectedItemChanged(args.OldValue, args.NewValue);
            OnPropertyChanged(nameof(SelectedIndex));
            RemoveCommand.RaiseCanExecuteChanged();
        }

        private void FireSelectedItemChanged(PersonViewModel oldValue, PersonViewModel newValue)
        {
            SelectedItemChanged?.Invoke(this, new ValueChangedEventArgs<PersonViewModel>(oldValue, newValue));
        }
    }
}
