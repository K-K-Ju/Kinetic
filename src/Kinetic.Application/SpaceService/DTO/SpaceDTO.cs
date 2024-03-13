using Kinetic.Core.Entities;
using Kinetic.Core.Entities.Space;
using Kinetic.Core.Entities.Space.BackLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinetic.Application.SpaceService.DTO
{
    public record SpaceDTO(
        int Id,
        string Name,
        User Owner,
        int OwnerId,
        SpaceBackLog SpaceBackLog,
        int SpaceBackLogId,
        TicketList Tickets,
        ICollection<Role> Roles,
        ICollection<SpaceUser> SpaceUsers,
        DateTime CreatedAt
    );
}
