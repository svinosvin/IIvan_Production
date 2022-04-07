using IvanProduction.Comands;
using IvanProduction.Model;
using IvanProduction.ViewModels.Base;
using System.Windows.Input;

namespace IvanProduction.State.Navigation
{
    public class Navigator : ObservableObject, INavigation
    {
        private ViewModel _currentViewModel;


        public ViewModel CurrentViewModel { 
            get { 
                return _currentViewModel; 
            } 
            set { 
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            } 
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
       
       
    }
}
