using System;
using System.Windows.Input;

namespace CodeBeerProject.ViewModels.Base
{
    class CommandBase : ICommand
    {
        private Action<object> execAction;
        private Func<object, bool> canExecFunc;

        #region Constructores
        public CommandBase(Action<object> execAction)
        {
            this.execAction = execAction;
            this.canExecFunc = null;
        }

        public CommandBase(Action<object> execAction, Func<object, bool> canExecFunc)
        {
            this.execAction = execAction;
            this.canExecFunc = canExecFunc;
        }

        public CommandBase(Action<object> execAction, object onLoginCommand)
        {
            this.execAction = execAction;
            this.canExecFunc = null;
        }
        #endregion

        //Implementación de la interfaz
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecFunc != null)
            {
                return canExecFunc.Invoke(parameter);
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            if (execAction != null)
            {
                execAction.Invoke(parameter);
            }
        }
    }
}