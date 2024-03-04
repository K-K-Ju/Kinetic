using Kinetic.Core.Entities.Space;
using Kinetic.Core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Azure;

namespace Kinetic.Infrastructure.Data
{
    public static class SeedingExtension
    {
        public static async Task DataBaseEnsureCreated(this IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<KineticDbContext>();
                var database = dbContext.Database;

                await database.EnsureDeletedAsync();
                await database.EnsureCreatedAsync();

                List<User> users = CreateUsers(10);

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
                    Owner = users[0],
                    OwnerId = users[0].Id,
                    CreatedAt = DateTime.Now
                };

                await dbContext.AddRangeAsync(users);
                await dbContext.AddAsync(space);
                await dbContext.AddRangeAsync(roles);
                space.Roles.Add(roles[0]);
                space.Roles.Add(roles[1]);
                await dbContext.SaveChangesAsync();

                SpaceUser spaceUser = new SpaceUser()
                {
                    Id = users[0].Id,
                    Space = space,
                    SpaceId = space.Id,
                    User = users[0],
                    UserRole = roles.ElementAt(0),
                    UserRoleId = roles.ElementAt(0).Id
                };
                
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
        public static List<User> CreateUsers(int amount)
        {
            var users = new List<User>();
            for (int i = 0; i < amount; i++)
            {
                users.Add(new User()
                {
                    FirstName = "Test" + i,
                    LastName = "LastTest",
                    ViewName = "ViewTest",
                    Email = "testmail",
                    PasswordHash = ""
                });
            }

            return users;
        }
    }
}
