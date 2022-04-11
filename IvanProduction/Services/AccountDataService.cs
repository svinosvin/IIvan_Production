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
    public class AccountDataService : IDataService<Account>
    {
        private readonly AppDbContextFactory _contextFactory;

        public AccountDataService(AppDbContextFactory appDbContext)
        {
            _contextFactory = appDbContext;
        }

        public async Task<Account> Create(Account entity)
        {

            using (AppDbContext context = _contextFactory.CreateDbContext())
            {

                EntityEntry<Account> createdResult = await context.Set<Account>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {

                Account entityEntry = await context.Set<Account>().FirstOrDefaultAsync((x) => x.Id == id);
                context.Set<Account>().Remove(entityEntry);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Account> Get(int id)
        {

            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts.Include(x => x.AccountHolder).Include(x=> x.historyTransactions).FirstOrDefaultAsync(x => x.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entity = await context.Accounts.Include(x => x.AccountHolder).Include(x => x.historyTransactions).ToListAsync();
                return entity;
            }
        }

        public async Task<Account> Update(int id, Account entity)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Accounts.Update(entity);
                await context.SaveChangesAsync();
                return entity;


            }
        }
    }
}
