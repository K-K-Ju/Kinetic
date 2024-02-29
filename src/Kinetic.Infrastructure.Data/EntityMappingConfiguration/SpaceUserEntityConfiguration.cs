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
                .WithMany()
                .HasForeignKey(su => su.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Navigation(su => su.User)
                .IsRequired();

            builder
                .HasOne(su => su.Space)
                .WithMany(x => x.SpaceUsers)
                .HasForeignKey(x => x.SpaceId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany<Ticket>()
                .WithOne(x => x.AssignedTo);

            builder
                .HasOne(x => x.UserRole)
                .WithOne()
                .HasForeignKey<SpaceUser>(x => x.UserRoleId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
