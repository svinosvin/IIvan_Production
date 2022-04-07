using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IvanProduction.Comands;
using IvanProduction.ViewModels.Base;

namespace IvanProduction.State.Navigation
{
    public enum ViewType
    {
        Home,
        History,
        Profile,
        About
    }
    public interface INavigation
    {
        ViewModel CurrentViewModel { get; set; }       
    }
}
