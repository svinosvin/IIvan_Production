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

        public HistoryTransactionsDataService(AppDbContextFactory appDbContext)
        {
            _contextFactory = appDbContext;
        }

        public async Task<HistoryTransactions> Create(HistoryTransactions entity)
        {

            using (AppDbContext context = _contextFactory.CreateDbContext())
            {

                EntityEntry<HistoryTransactions> createdResult = await context.Set<HistoryTransactions>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {

                HistoryTransactions entityEntry = await context.Set<HistoryTransactions>().FirstOrDefaultAsync((x) => x.Id == id);
                context.Set<HistoryTransactions>().Remove(entityEntry);
                await context.SaveChangesAsync();
                return true;
            }
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
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Histories.Update(entity);
                await context.SaveChangesAsync();
                return entity;


            }
        }
    }
}
