using Kinetic.Infrastructure.Data;
using Kinetic.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Kinetic.WebUI;
using Kinetic.Application;
using Serilog;

namespace Kinetic.WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            string? connectionString = builder.Configuration.GetConnectionString("LocalDbSqlServer");
            builder.Host.UseSerilog((context, loggerConfig) =>
                loggerConfig.ReadFrom.Configuration(context.Configuration));

            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddStorage(connectionString ?? string.Empty);
            services.AddIdentityStorage(connectionString ?? string.Empty);

            services.AddApplicationServices();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<UserIdentityDbContext>();

            services.AddLogging();

            services.AddControllersWithViews();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

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
