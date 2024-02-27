using Kinetic.Core.Entities.Space.BackLog;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Kinetic.Core.Entities.Space
{
    public class Space
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual User Owner { get; set; }
        public int OwnerId { get; set; }
        public virtual SpaceBackLog SpaceBackLog { get; set; }
        public TicketList Tickets { get; }
        public ICollection<Role> Roles { get; }
        public IDictionary<User, Role> UserRoles { get; }
        public DateTime CreatedAt { get; set; }

        public Space()
        {
            TicketList tickets = new TicketList() { space = this };
        }

        public class TicketList : List<Ticket>
        {
            public Space space { get; set; }
            public new void Add(Ticket ticket)
            {
                ticket.TicketStateChanged += space.SpaceBackLog.OnTicketStateChange; 
                base.Add(ticket);
            }
        }
    }
}