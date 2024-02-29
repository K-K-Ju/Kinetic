namespace Kinetic.Core.Entities.Space.Restrictions
{
    public abstract class Restriction
    {
        public int Id { get; set; }
        public ICollection<TicketAction> RestrictedTicketActions { get; set; } = new List<TicketAction>();
    }
}