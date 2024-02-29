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
                .Property(x => x.FirstName)
                .IsRequired();

            builder 
                .Property(x => x.LastName)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .IsRequired();

            builder
                .Property(x => x.ViewName);

            builder
                .HasMany(x => x.Spaces)
                .WithOne(x => x.Owner);
        }
    }
}
