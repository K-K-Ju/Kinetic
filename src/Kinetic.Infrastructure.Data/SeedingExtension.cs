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
    public static class SeedingExtension
    {
        public static async Task SeedTestDataAsync(this IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<KineticDbContext>();
                var userStore = scope.ServiceProvider.GetRequiredService<IUserStore<IdentityUser>>();
                var emailStore = (IUserEmailStore<IdentityUser>)userStore;
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var identityDbContext = scope.ServiceProvider.GetRequiredService<UserIdentityDbContext>();

                var identityUser = Activator.CreateInstance<IdentityUser>();
                var email = "test@mail.com";
                await userStore.SetUserNameAsync(identityUser, email, CancellationToken.None);
                await emailStore.SetEmailAsync(identityUser, email, CancellationToken.None);
                identityUser.EmailConfirmed = true;
                var result = await userManager.CreateAsync(identityUser, "!Mypass12");

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException("Identity user wasn't seeded.");
                }

                var user = new User()
                {
                    FirstName = "Test",
                    LastName = "LastTest",
                    Email = email,
                    IdentityId = await userManager.GetUserIdAsync(identityUser)
                };

                dbContext.Users.Add(user);

                var roles = new List<Role>()
                {
                    new Role()
                    {
                        Name = "Dev"
                    },
                    new Role()
                    {
                        Name = "Dev"
                    },
                };

                Space space = new Space()
                {
                    Name = "Test",
                    Owner = user,
                    OwnerId = user.Id,
                    CreatedAt = DateTime.Now
                };

                space.Roles.Add(roles[0]);
                space.Roles.Add(roles[1]);

                SpaceUser spaceUser = new SpaceUser()
                {
                    Id = user.Id,
                    Space = space,
                    SpaceId = space.Id,
                    User = user,
                    UserRole = roles.ElementAt(0),
                    UserRoleId = roles.ElementAt(0).Id
                };

                dbContext.Roles.Add(roles[0]);
                dbContext.Roles.Add(roles[1]);

                await dbContext.AddAsync(spaceUser);

                space.SpaceUsers.Add(spaceUser);

                await dbContext.SaveChangesAsync();

                Ticket ticket = new Ticket()
                {
                    Title = "TestTicket",
                    Creator = spaceUser,
                    CreatorId = spaceUser.Id
                };

                space.Tickets.Add(ticket);
                ticket.AssignedTo = spaceUser;
                ticket.AssignedToId = spaceUser.Id;
                ticket.CurrentState = Ticket.State.IN_PROGRESS;

                await dbContext.AddAsync(ticket);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
