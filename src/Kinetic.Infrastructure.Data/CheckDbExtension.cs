using Kinetic.Core.Entities.Space;
using Kinetic.Core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Kinetic.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Kinetic.Infrastructure.Data
{
    public static class CheckDbExtension
    {
        public static async Task PrepareDataBaseAsync(this IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<KineticDbContext>();
                var identityDbContext = scope.ServiceProvider.GetRequiredService<UserIdentityDbContext>();

                await dbContext.Database.EnsureDeletedAsync();
                await dbContext.Database.MigrateAsync();

                await identityDbContext.Database.MigrateAsync();
            }
        }
    }
}
