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
    internal class NonQueryDataService<T> where T : DomainObject
    {
        private readonly AppDbContextFactory _contextFactory;

        public NonQueryDataService(AppDbContextFactory appDbContext)
        {
            _contextFactory = appDbContext;
        }

        public async Task<T> Create(T entity)
        {

            using (AppDbContext context = _contextFactory.CreateDbContext())
            {

                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {

                T entityEntry = await context.Set<T>().FirstOrDefaultAsync((x) => x.Id == id);
                context.Set<T>().Remove(entityEntry);
                await context.SaveChangesAsync();
                return true;
            }
        }
        public async Task<T> Update(int id, T entity)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;


            }
        }
    }
}
