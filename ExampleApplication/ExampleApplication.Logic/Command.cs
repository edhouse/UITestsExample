using System;
using System.Windows.Input;

namespace ExampleApplication.Logic
{
    public class Command : ViewModelBase, ICommand
    {
        private Action<object> executeAction;
        private Func<object, bool> canExecuteFunc;
        private string name;
        private string description;

        public Command(string name, string description, Action<object> executeAction, Func<object, bool> canExecuteFunc = null)
        {
            Name = name;
            Description = description;
            this.executeAction = executeAction;
            this.canExecuteFunc = canExecuteFunc;
        }

        public Command(Action<object> executeAction, Func<object, bool> canExecuteFunc = null)
            :this(null, null, executeAction, canExecuteFunc)
        {
        }

        public event EventHandler CanExecuteChanged;

        public string Name
        {
            get { return name; }
            set { SetProperty(nameof(Name), ref name, value); }
        }

        public string Description
        {
            get { return description; }
            set { SetProperty(nameof(Description), ref description, value); }
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteFunc == null || canExecuteFunc(parameter);
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
            {
                throw new InvalidOperationException("Can not execute");
            }

            executeAction(parameter);
        }

        private void FireCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RaiseCanExecuteChanged()
        {
            FireCanExecuteChanged();
        }
    }
}
