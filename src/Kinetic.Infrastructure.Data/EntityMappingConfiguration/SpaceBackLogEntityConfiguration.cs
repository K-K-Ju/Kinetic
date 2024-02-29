using Kinetic.Core.Entities.Space;
using Kinetic.Core.Entities.Space.BackLog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kinetic.Infrastructure.Data.EntityMappingConfiguration
{
    public class SpaceBackLogEntityConfiguration : IEntityTypeConfiguration<SpaceBackLog>
    {
        public void Configure(EntityTypeBuilder<SpaceBackLog> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.ParentSpace)
                .WithOne(x => x.SpaceBackLog)
                .HasForeignKey<SpaceBackLog>(x => x.ParentSpaceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Logs)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
