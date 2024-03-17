using Kinetic.Core.Entities.Space;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinetic.Application.DTO
{
    public record TicketDTO(
        int Id,
        string Title,
        string Description,
        Ticket.State CurrentState,
        TicketPriority Priority,
        SpaceUser Creator,
        SpaceUser? AssignedTo,
        ICollection<Task>? Subtasks,
        ICollection<Tag> Tags
    );
}
