using Kinetic.Core.Entities.Space.BackLog;

namespace Kinetic.Core.Entities.Space
{
    public partial class Space
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual User Owner { get; set; }
        public int OwnerId { get; set; }
        public virtual SpaceBackLog SpaceBackLog { get; set; } = new SpaceBackLog();
        public int SpaceBackLogId { get; set; }
        public TicketList Tickets { get; }
        public ICollection<Role> Roles { get; } = new List<Role>();
        public ICollection<SpaceUser> SpaceUsers { get; } = new List<SpaceUser>();
        public DateTime CreatedAt { get; set; }

        public Space()
        {
            Tickets = new TicketList(this, SpaceBackLog);
        }
    }
}