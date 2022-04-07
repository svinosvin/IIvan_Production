using IvanProduction.State.Navigation;
using IvanProduction.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanProduction.ViewModels
{
    public class UserMainWindowView :ViewModel
    {
        public INavigation Navigator { get; set; } = new Navigator();

    }
}
