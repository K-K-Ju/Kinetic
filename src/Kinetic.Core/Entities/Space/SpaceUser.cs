namespace Kinetic.Core.Entities.Space
{
    public class SpaceUser
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public Role SpaceUserRole { get; set; }
        public int SpaceUserRoleId { get; set; }
        public Space Space { get; set; }
        public int SpaceId { get; set; }
        public ICollection<Ticket> AssignedTickets { get; } = new List<Ticket>();
    }
}
