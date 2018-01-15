using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExampleApplication.Logic
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(string propertyName, ref T propertyField, T value)
        {
            if (!EqualityComparer<T>.Default.Equals(propertyField, value))
            {
                propertyField = value;
                OnPropertyChanged(propertyName);
            }
        }

        protected void SetProperty<T>(string propertyName, ref T propertyField, T value, Action executeOnChange)
        {
            if (!EqualityComparer<T>.Default.Equals(propertyField, value))
            {
                propertyField = value;
                executeOnChange?.Invoke();
                OnPropertyChanged(propertyName);
            }
        }

        protected void SetProperty<T>(string propertyName, ref T propertyField, T value, Action<ValueChangedEventArgs<T>> executeOnChange)
        {
            if (!EqualityComparer<T>.Default.Equals(propertyField, value))
            {
                T oldValue = propertyField;
                propertyField = value;
                executeOnChange?.Invoke(new ValueChangedEventArgs<T>(oldValue, value));
                OnPropertyChanged(propertyName);
            }
        }
    }
}
