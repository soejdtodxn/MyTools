using System;
using System.Windows.Input;

namespace MyTools.TempLibrary
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<object> _Execute;
        Func<object, bool> _CanExecute;

        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _Execute(parameter);
        }
    }
}
