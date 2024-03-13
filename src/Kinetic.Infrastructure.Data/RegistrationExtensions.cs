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
        public static void AddIdentityStorage(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<UserIdentityDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqloptions =>
                {
                    sqloptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, UserIdentityDbContext.Schema);
                });
            });
        }

    }
}
