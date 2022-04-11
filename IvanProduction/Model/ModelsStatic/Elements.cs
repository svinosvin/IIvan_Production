using IvanProduction.Data;
using IvanProduction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanProduction.Model.ModelsStatic
{
    static public class Elements
    {
        static private AppDbContextFactory appDbContext { get; set; } = new AppDbContextFactory();
        static public IDataService<Book> BooksElements { get; set; } = new GenericDataService<Book>(appDbContext);
        static public IDataService<User> UserElements { get; set; } = new GenericDataService<User>(appDbContext);
        static public IDataService<Account> AccountElements { get; set; } = new AccountDataService(appDbContext);
        static public IDataService<HistoryTransactions> HistoryElements { get; set; } = new HistoryTransactionsDataService(appDbContext);
        static public IDataService<Admin> AdminsElements { get; set; } = new GenericDataService<Admin>(appDbContext);


    }
}
