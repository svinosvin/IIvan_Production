using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanProduction.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseSqlite(@"Data Source=G:\Курсовой проект\IvanProduction\Library.db");
            Console.WriteLine(options.IsConfigured);
            return new AppDbContext(options.Options);
        }
    }
}
