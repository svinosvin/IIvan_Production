using IvanProduction.State.Navigation;
using IvanProduction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IvanProduction.Comands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigation _navigator;
        
        public UpdateCurrentViewModelCommand(INavigation navigator)
        {
            _navigator = navigator;
           
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Home:  
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.History: break;
                    case ViewType.Profile:
                        _navigator.CurrentViewModel = new ProfileViewModel();
                        break;
                    case ViewType.About: break;


                }
            }
            
        }
    }
}
