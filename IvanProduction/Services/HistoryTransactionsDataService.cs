using IvanProduction.Data;
using IvanProduction.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanProduction.Services
{
    public class HistoryTransactionsDataService:IDataService<HistoryTransactions>
    {
        private readonly AppDbContextFactory _contextFactory;
        private readonly NonQueryDataService<HistoryTransactions> _nonQueryDataService;

        public HistoryTransactionsDataService(AppDbContextFactory appDbContext)
        {
            _contextFactory = appDbContext;
            _nonQueryDataService = new NonQueryDataService<HistoryTransactions>(appDbContext);
        }

        public async Task<HistoryTransactions> Create(HistoryTransactions entity)
        {

            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<HistoryTransactions> Get(int id)
        {

            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                HistoryTransactions entity = await context.Histories.Include(x => x.Book).Include(x => x.Account).FirstOrDefaultAsync(x => x.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<HistoryTransactions>> GetAll()
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<HistoryTransactions> entity = await context.Histories.Include(x => x.Book).Include(x => x.Account).ToListAsync();
                return entity;
            }
        }

        public async Task<HistoryTransactions> Update(int id, HistoryTransactions entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task AddGoodTransaction(Book book, Account account, HistoryTransactions hs) {

            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
               
                await context.Histories.AddAsync(hs);
                hs.Book = book;
                hs.Account = account;
                context.SaveChanges();
            }
        }
        
    }
}
