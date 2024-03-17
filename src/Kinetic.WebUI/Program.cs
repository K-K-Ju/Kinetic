using Kinetic.Infrastructure.Data;
using Kinetic.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Kinetic.WebUI;
using Kinetic.Application;

namespace Kinetic.WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            string? connectionString = builder.Configuration.GetConnectionString("LocalDbSqlServer");

            services.AddHttpContextAccessor();
            services.AddStorage(connectionString ?? string.Empty);
            services.AddIdentityStorage(connectionString ?? string.Empty);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddApplicationServices();
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<UserIdentityDbContext>();

            services.AddLogging();

            services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            { }

            await app.PrepareDataBaseAsync();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            await app.SeedTestDataAsync();
            app.Run();

        }
    }
}
