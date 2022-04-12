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
        private readonly NonQueryDataService<Account> _nonQueryDataService;
        public AccountDataService(AppDbContextFactory appDbContext)
        {
            _contextFactory = appDbContext;
            _nonQueryDataService = new NonQueryDataService<Account>(appDbContext);
        }

        public async Task<Account> Create(Account entity)
        {


            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Account> Get(int id)
        {

            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts.Include(x => x.AccountHolder).Include(x=> (x.historyTransactions)).FirstOrDefaultAsync(x => x.Id == id);
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
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
