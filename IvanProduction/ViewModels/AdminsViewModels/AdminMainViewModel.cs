using IvanProduction.Model;
using IvanProduction.State.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanProduction.ViewModels.AdminsViewModels
{
    public class AdminMainViewModel : Base.ViewModel
    {
        public INavigation Navigator { get; set; } = new Navigator();
        static public Admin ActiveAdmin { get; set; } = new Admin();

        public AdminMainViewModel(/*Admin admin*/)
        {

        }
    }
}
