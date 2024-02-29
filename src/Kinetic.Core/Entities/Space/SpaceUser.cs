namespace Kinetic.Core.Entities.Space
{
    public class SpaceUser
    {
        public int Id { get; set; }
        public User User { get; set; }
        public virtual Role UserRole { get; set; }
        public int UserRoleId { get; set; }
        public Space Space { get; set; }
        public int SpaceId { get; set; }
        public ICollection<Ticket> AssignedTickets { get; } = new List<Ticket>();
    }
}
