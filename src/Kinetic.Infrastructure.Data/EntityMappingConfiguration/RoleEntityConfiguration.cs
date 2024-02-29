using Kinetic.Core.Entities.Space;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kinetic.Infrastructure.Data.EntityMappingConfiguration
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            
            builder
                .HasMany(r => r.Restrictions)
                .WithOne()
                .IsRequired(false);
        }
    }
}
