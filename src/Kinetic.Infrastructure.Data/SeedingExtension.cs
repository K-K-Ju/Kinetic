using Kinetic.Core.Entities.Space;
using Kinetic.Core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Kinetic.Infrastructure.Identity;

namespace Kinetic.Infrastructure.Data
{
    public static class SeedingExtension
    {
        public static async Task DataBaseEnsureCreated(this IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<KineticDbContext>();
                var identityDbContext = scope.ServiceProvider.GetRequiredService<UserIdentityDbContext>();

                await dbContext.Database.EnsureDeletedAsync();
                await dbContext.Database.MigrateAsync();
                await identityDbContext.Database.MigrateAsync();

                //List<User> users = CreateUsers(5);

                //var roles = new List<Role>()
                //{
                //    new Role()
                //    {
                //        Name = "Dev"
                //    },
                //    new Role()
                //    {
                //        Name = "Dev"
                //    },
                //};

                //Space space = new Space()
                //{
                //    Name = "Test",
                //    Owner = users[0],
                //    OwnerId = users[0].Id,
                //    CreatedAt = DateTime.Now
                //};

                //space.Roles.Add(roles[0]);
                //space.Roles.Add(roles[1]);

                //SpaceUser spaceUser = new SpaceUser()
                //{
                //    Id = users[0].Id,
                //    Space = space,
                //    SpaceId = space.Id,
                //    User = users[0],
                //    UserRole = roles.ElementAt(0),
                //    UserRoleId = roles.ElementAt(0).Id
                //};

                //dbContext.Roles.Add(roles[0]);
                //dbContext.Roles.Add(roles[1]);

                //await dbContext.AddAsync(spaceUser);

                //space.SpaceUsers.Add(spaceUser);

                //await dbContext.SaveChangesAsync();

                //Ticket ticket = new Ticket()
                //{
                //    Title = "TestTicket",
                //    Creator = spaceUser,
                //    CreatorId = spaceUser.Id
                //};

                //space.Tickets.Add(ticket);
                //ticket.AssignedTo = spaceUser;
                //ticket.AssignedToId = spaceUser.Id;
                //ticket.CurrentState = Ticket.State.IN_PROGRESS;

                //await dbContext.AddAsync(ticket);
                await dbContext.SaveChangesAsync();
            }
        }
        //public static List<User> CreateUsers(int amount)
        //{
        //    var users = new List<User>();
        //    for (int i = 0; i < amount; i++)
        //    {
        //        users.Add(new User()
        //        {
        //            FirstName = "Test" + i,
        //            LastName = "LastTest",
        //            UserName = "ViewTest",
        //            Email = "testmail"
        //        });
        //    }

        //    return users;
        //}
    }
}
