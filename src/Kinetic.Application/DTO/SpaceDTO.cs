using Kinetic.Core.Entities;
using Kinetic.Core.Entities.Space;
using Kinetic.Core.Entities.Space.BackLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinetic.Application.DTO
{
    public record SpaceDTO(
        int Id,
        string? Name,
        User? Owner,
        int OwnerId,
        SpaceBackLog? SpaceBackLog,
        int SpaceBackLogId,
        TicketList? Tickets,
        ICollection<Role>? Roles,
        ICollection<SpaceUser>? SpaceUsers,
        DateTime? CreatedAt
    )
    {
        public SpaceDTO() : this(
            0, null, null,
            0, null, 0,
            null, null, null,
            DateTime.MinValue)
        { }
    }
}
