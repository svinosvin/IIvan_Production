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
                
          
            ActiveUser.historyTransactions = Elements.HistoryElements.GetAll().Result?.Where(x => x.Account.Id == ActiveUser.Id).ToList();
            
            //ActiveUser.AccountHolder = user;
           
           // Elements.AccountElements.Create(new Account { AccountHolder = new User { Email = "321" });

        }


        public static void UpdateAccount(User acc)
        {
            ActiveUser.AccountHolder = acc;
            Elements.UserElements.Update(ActiveUser.Id, acc);
           // ActiveUser.historyTransactions = Elements.HistoryElements.GetAll().Result?.Where(x => x.Account.Id == ActiveUser.Id);

        }
        public static void UpdateBook(Book book,int id)
        {
            Elements.BooksElements.Update(id, book);
        }

        public static  void UpdateHistories(HistoryTransactions hs)
        {
             Elements.HistoryElements.Create(hs);
          //  UpdateAccount(ActiveUser.AccountHolder);
        }



    }
}
