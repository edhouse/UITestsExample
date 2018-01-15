using System;

namespace ExampleApplication.Logic
{
    public class PersonViewModel : ViewModelBase, ICloneable
    {
        private string firstName;
        private string lastName;
        private string description;

        public PersonViewModel(string firstName, string lastName, string description)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.description = description;
        }

        public event EventHandler FirstNameChanged;
        public event EventHandler LastNameChanged;
        public event EventHandler WholeNameChanged;
        public event EventHandler DescriptionChanged;

        public string WholeName
        {
            get { return FirstName + " " + LastName; }
        }
        
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(nameof(FirstName), ref firstName, value, OnFirstNameChanged); }
        }

        public string LastName
        {
            get { return lastName; }
            set { SetProperty(nameof(LastName), ref lastName, value, OnLastNameChanged); }
        }

        public string Description
        {
            get { return description; }
            set { SetProperty(nameof(Description), ref description, value, OnDescriptionChanged); }
        }

        public object Clone()
        {
            return new PersonViewModel(FirstName, LastName, Description);
        }

        private void OnFirstNameChanged()
        {
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(WholeName));
            FireFirstNameChanged();
            FireWholeNameChanged();
        }

        private void OnLastNameChanged()
        {
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(WholeName));
            FireLastNameChanged();
            FireWholeNameChanged();
        }

        private void OnDescriptionChanged()
        {
            OnPropertyChanged(nameof(Description));
            FireDescriptionChanged();
        }

        private void FireFirstNameChanged()
        {
            FirstNameChanged?.Invoke(this, EventArgs.Empty);
        }

        private void FireLastNameChanged()
        {
            LastNameChanged?.Invoke(this, EventArgs.Empty);
        }

        private void FireWholeNameChanged()
        {
            WholeNameChanged?.Invoke(this, EventArgs.Empty);
        }

        private void FireDescriptionChanged()
        {
            DescriptionChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
