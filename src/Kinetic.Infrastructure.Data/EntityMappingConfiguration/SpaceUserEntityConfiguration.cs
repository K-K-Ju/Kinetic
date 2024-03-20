using Kinetic.Core.Entities;
using Kinetic.Core.Entities.Space;
using Microsoft.EntityFrameworkCore;

namespace Kinetic.Infrastructure.Data.EntityMappingConfiguration
{
    public class SpaceUserEntityConfiguration : IEntityTypeConfiguration<SpaceUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SpaceUser> builder)
        {
            builder.
                HasKey(x => x.Id);

            builder
                .HasOne(su => su.User)
                .WithMany(u => u.SpaceUsers)
                .HasForeignKey(su => su.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Navigation(su => su.User)
                .EnableLazyLoading()
                .IsRequired();

            builder
                .HasOne(su => su.Space)
                .WithMany(x => x.SpaceUsers)
                .HasForeignKey(x => x.SpaceId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(su => su.AssignedTickets)
                .WithOne(t => t.AssignedTo)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.SpaceUserRole)
                .WithOne()
                .HasForeignKey<SpaceUser>(x => x.SpaceUserRoleId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
