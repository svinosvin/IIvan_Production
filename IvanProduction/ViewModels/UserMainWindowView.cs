using IvanProduction.Model;
using IvanProduction.Model.ModelsStatic;
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

        static public Account ActiveUser { get; set; } = new Account();


        public UserMainWindowView(/*User user*/)
        {
                
            ActiveUser = Elements.AccountElements.GetAll().Result.FirstOrDefault(x => (x.AccountHolder.Id) == 1);
     
            
            //ActiveUser.AccountHolder = user;
            // Elements.AccountElements.Create(new Account { AccountHolder = new User { Email = "321", Name = } })

        }

    }
}
