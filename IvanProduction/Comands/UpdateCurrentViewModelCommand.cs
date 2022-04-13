using IvanProduction.Model;
using IvanProduction.State.Navigation;
using IvanProduction.ViewModels;
using IvanProduction.ViewModels.AdminsViewModels;
using System;
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
            if(!UserOrAdminActive.AdminActive)
                Execute(ViewType.Home); 
            else
               Execute(AdminViewType.Books);



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
                    case ViewType.History:
                        _navigator.CurrentViewModel = new HistoryViewModel();
                        break;
                    case ViewType.Profile:
                        _navigator.CurrentViewModel = new ProfileViewModel();
                        break;
                    case ViewType.About:
                        _navigator.CurrentViewModel = new AboutViewModel(); 
                        break;

                }
            }
            if(parameter is AdminViewType)
            {
                AdminViewType viewType = (AdminViewType)parameter;
                switch (viewType)
                {
                    case AdminViewType.NewAdmin:
                        _navigator.CurrentViewModel = new AdminAdminsViewModel();
                        break;
                    case AdminViewType.History:
                        _navigator.CurrentViewModel = new AdminHistoryViewModel();
                        break;
                    case AdminViewType.Profile:
                        _navigator.CurrentViewModel = new AdminProfileViewModel();
                        break;
                    case AdminViewType.Books:
                        _navigator.CurrentViewModel = new AdminBooksViewModel();
                        break;
                    case AdminViewType.Users:
                        _navigator.CurrentViewModel = new AdminUsersViewModel();
                        break;
                    
                }
            }
            
        }
    }
}
