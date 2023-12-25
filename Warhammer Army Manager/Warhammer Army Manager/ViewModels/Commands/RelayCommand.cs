using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Warhammer_Army_Manager.ViewModels.Commands
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object> executeAction, Func<object, bool> canExecuteAction)
        {
            execute = executeAction;
            canExecute = canExecuteAction;
        }

        public void Execute(object parameter) => execute(parameter);

        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;

    }
}
