using Kinetic.Application.Abstraction;
using Kinetic.Infrastructure.Data;
using Kinetic.Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinetic.Application
{
    public static class RegistrationExtensions
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISpaceService, Services.SpaceService>();
            serviceCollection.AddScoped<IUserService, Services.UserService>();
            serviceCollection.AddScoped<KineticDbContext>();
        }

    }
}
