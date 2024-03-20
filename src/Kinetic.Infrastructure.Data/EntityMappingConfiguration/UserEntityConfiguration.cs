using Kinetic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kinetic.Infrastructure.Data.EntityMappingConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Spaces)
                .WithOne(x => x.Owner);

            builder
                .HasMany(x => x.SpaceUsers)
                .WithOne(su => su.User)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
