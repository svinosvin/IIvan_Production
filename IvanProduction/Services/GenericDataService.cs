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
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly AppDbContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;
        public GenericDataService(AppDbContextFactory appDbContext)
        {
            _contextFactory = appDbContext;
            _nonQueryDataService = new NonQueryDataService<T>(appDbContext);
        }

        public async Task<T> Create(T entity)
        {


            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<T> Get(int id)
        {

            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entity = await context.Set<T>().ToListAsync();
                return entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
