using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp_Material_MVVM_BD.Infrastracture
{
    class RelayCommand : ICommand
    {
       readonly Action<object> action;
        public RelayCommand(Action<object> action)
        {
            this.action = action;
        }
        public event EventHandler CanExecuteChanged;
        

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
