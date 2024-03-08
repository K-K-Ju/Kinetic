using Kinetic.Infrastructure.Data;
using Kinetic.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kinetic.WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            string? connectionString = builder.Configuration.GetConnectionString("LocalDbSqlServer");

            //services.AddDbContext<KineticDbContext>(options => options.UseSqlServer(connectionString));
            

            services.AddDbContext<UserIdentityDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqloptions =>
                {
                    sqloptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, UserIdentityDbContext.Schema);
                });
            });

            services.AddStorage(connectionString ?? string.Empty);

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<UserIdentityDbContext>();

            services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            { }

            await app.DataBaseEnsureCreated();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.Map("/login", async (AuthenticationService authService, IHttpContextAccessor httpContextAccessor) =>
            //{
            //    await authService.SignInAsync(new ClaimsPrincipal());
            //});

            app.Run();
        }
    }
}
