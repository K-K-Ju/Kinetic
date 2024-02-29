using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinetic.Core.Entities.Space
{
    [NotMapped]
    public class TicketStateChangedEventArgs : EventArgs
    {
        public int InitiatorId { get; set; }
        public int TicketId { get; set; }
        public Ticket.State OldState { get; set; }
        public Ticket.State NewState { get; set; }
    }
}