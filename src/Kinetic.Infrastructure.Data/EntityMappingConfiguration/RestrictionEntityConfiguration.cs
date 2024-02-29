using Kinetic.Core.Entities.Space;
using Kinetic.Core.Entities.Space.Restrictions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kinetic.Infrastructure.Data.EntityMappingConfiguration
{
    public class RestrictionEntityConfiguration : IEntityTypeConfiguration<Restriction>
    {
        public void Configure(EntityTypeBuilder<Restriction> builder)
        {
            builder.HasKey(r => r.Id);
        }
    }
}
