using Kinetic.Core.Entities.Space;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kinetic.Infrastructure.Data.EntityMappingConfiguration
{
    public class SpaceEntityConfiguration : IEntityTypeConfiguration<Space>
    {
        public void Configure(EntityTypeBuilder<Space> builder)
        {
            builder.HasKey(s => s.Id);

            builder
                .HasMany(s => s.Roles)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(s => s.Owner)
                .WithMany(u => u.Spaces)
                .HasForeignKey(s => s.OwnerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(s => s.Tickets)
                .WithOne()
                .IsRequired(false);

            builder
                .HasMany(s => s.SpaceUsers)
                .WithOne(su => su.Space);

            builder
                .HasOne(s => s.SpaceBackLog)
                .WithOne(sbl => sbl.ParentSpace)
                .HasForeignKey<Space>(x => x.SpaceBackLogId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(s => s.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getdate()");
        }
    }
}
