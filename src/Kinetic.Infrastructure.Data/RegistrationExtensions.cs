using Kinetic.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kinetic.Infrastructure.Data
{
    public static class RegistrationExtensions
    {
        public static void AddStorage(this IServiceCollection serviceCollection, string connectionString) 
        {
            serviceCollection.AddDbContext<KineticDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
