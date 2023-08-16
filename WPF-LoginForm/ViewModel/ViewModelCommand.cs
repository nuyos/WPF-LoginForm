using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_LoginForm.ViewModel
{
    internal class ViewModelCommand : ICommand
    {
        private readonly Action<object> _execteAction;
        private readonly Predicate<object> _canExecuteAction;

        public ViewModelCommand(Action<object> execteAction)
        {
            _execteAction = execteAction;
            _canExecuteAction = null;
        }
        public ViewModelCommand(Action<object> execteAction, Predicate<object> canExecuteAction)
        {
            _execteAction = execteAction;
            _canExecuteAction = canExecuteAction;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteAction == null?true : _canExecuteAction(parameter);
        }

        public void Execute(object parameter)
        {
            _execteAction(parameter);
        }
    }
}
