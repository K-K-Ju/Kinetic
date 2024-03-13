using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinetic.Infrastructure.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<KineticDbContext>
    {
        public KineticDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KineticDbContext>();
            optionsBuilder.UseSqlServer("Data Source=ANDREW\\SQLEXPRESS;Initial Catalog=kinetic;Integrated Security=True;Trust Server Certificate=True;Connect Timeout=30;Encrypt=False");

            return new KineticDbContext(optionsBuilder.Options);
        }
    }
}
