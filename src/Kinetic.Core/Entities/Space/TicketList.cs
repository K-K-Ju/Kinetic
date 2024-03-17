using Kinetic.Core.Entities.Space.BackLog;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinetic.Core.Entities.Space
{
    [NotMapped]
    public class TicketList : List<Ticket>
    {
        public Space Space { get; set; }
        private SpaceBackLog _spaceBackLog;

        public TicketList(Space space, SpaceBackLog spaceBackLog)
        {
            Space = space;
            _spaceBackLog = spaceBackLog;
        }

        public TicketList() : this(null, null)
        { }

        public new void Add(Ticket ticket)
        {
            ticket.TicketStateChanged += _onTicketStateChange;
            base.Add(ticket);
        }

        private void _onTicketStateChange(object sender, TicketStateChangedEventArgs eventArgs)
        {
            _spaceBackLog.Logs.Add(new ParamChangeLog<Ticket.State>()
            {
                From = eventArgs.OldState,
                To = eventArgs.NewState,
                InitiatorId = eventArgs.InitiatorId,
                ClassName = typeof(Ticket).Name,
            });
        }
    }
}