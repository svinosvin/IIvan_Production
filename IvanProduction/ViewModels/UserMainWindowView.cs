using IvanProduction.Model;
using IvanProduction.Model.ModelsStatic;
using IvanProduction.State.Navigation;
using IvanProduction.ViewModels.Base;
using System.Linq;

namespace IvanProduction.ViewModels
{
    public class UserMainWindowView :ViewModel
    {
        public INavigation Navigator { get; set; } = new Navigator();

        static public Account ActiveUser { get; set; } = new Account();


        public UserMainWindowView(/*User user*/)
        {
                
            ActiveUser = Elements.AccountElements.GetAll().Result.FirstOrDefault(x => (x.AccountHolder.Id) == 1);
            ActiveUser.historyTransactions = Elements.HistoryElements.GetAll().Result?.Where(x => x.Account.Id == ActiveUser.Id);

            //ActiveUser.AccountHolder = user;
            // Elements.AccountElements.Create(new Account { AccountHolder = new User { Email = "321", Name = } })

        }


        public static void UpdateAccount(User acc)
        {
            ActiveUser.AccountHolder = acc;
            Elements.UserElements.Update(ActiveUser.Id, acc);


        }
        public static void UpdateBook(Book book,int id)
        {
            Elements.BooksElements.Update(id, book);
        }






    }
}
