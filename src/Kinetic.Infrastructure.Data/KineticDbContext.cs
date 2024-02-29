using Kinetic.Core.Entities;
using Kinetic.Core.Entities.Space;
using Kinetic.Core.Entities.Space.BackLog;
using Kinetic.Core.Entities.Space.Restrictions;
using Microsoft.EntityFrameworkCore;

namespace Kinetic.Infrastructure.Data
{
    public class KineticDbContext : DbContext
    {
        public KineticDbContext(DbContextOptions options) : base(options) { }
        public KineticDbContext() { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<SpaceUser> SpaceUsers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<SpaceBackLog> SpaceBackLogs { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<TagRestriction> TagRestrictions { get; set; }
        public DbSet<PriorityRestriction> PriorityRestrictions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KineticDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
