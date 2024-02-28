using Kinetic.Core.Entities.Space;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kinetic.Core.Entities.Space
{
    public class SpaceUser
    {
        public int UserId { get; set; }
        public virtual Role UserRole { get; set; }
        public int UserRoleId { get; set; }
        public Space Space { get; set; }
        public int SpaceId { get; set; }
        public ICollection<Ticket> AssignedTickets { get; } = new List<Ticket>();
    }
}
