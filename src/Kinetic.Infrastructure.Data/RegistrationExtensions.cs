using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kinetic.Infrastructure.Data
{
    public static class RegistrationExtensions
    {
        public static void AddStorage(this IServiceCollection serviceCollection, IConfiguration configuration) 
        {
            serviceCollection.AddDbContext<KineticDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LocalDbSqlServer"));
            });
        }
    }
}
