using Kinetic.Core.Entities.Space;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kinetic.Infrastructure.Data.EntityMappingConfiguration
{
    public class TicketEntityConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Creator)
                .WithMany()
                .HasForeignKey(x => x.CreatorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            //builder
            //    .HasOne(x => x.AssignedTo)
            //    .WithMany(x => x.AssignedTickets)
            //    .HasForeignKey(x => x.AssignedToId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.SubTasks)
                .WithOne()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
