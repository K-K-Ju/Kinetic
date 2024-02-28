using Kinetic.Core.Entities.Space.BackLog;

namespace Kinetic.Core.Entities.Space
{
    public class Space
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual User Owner { get; set; }
        public int OwnerId { get; set; }
        public virtual SpaceBackLog SpaceBackLog { get; set; }
        public int SpaceBackLogId { get; set; }
        public TicketList Tickets { get; }
        public ICollection<Role> Roles { get; } = new List<Role>();
        public ICollection<SpaceUser> SpaceUsers { get; }
        public DateTime CreatedAt { get; set; }

        public Space()
        {
            TicketList tickets = new TicketList(this);
        }

        public class TicketList : List<Ticket>
        {
            public Space space { get; set; }

            public TicketList(Space space)
            {
                this.space = space;
            }

            public new void Add(Ticket ticket)
            {
                ticket.TicketStateChanged += space.SpaceBackLog.OnTicketStateChange; 
                base.Add(ticket);
            }
        }
    }
}