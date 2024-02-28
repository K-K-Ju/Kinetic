using System;
using System.Collections;
using System.Collections.Generic;

namespace Kinetic.Core.Entities.Space
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public State CurrentState {
            get { return CurrentState; }
            set 
            {
                OnTicketStateChanged(this, new TicketStateChangedEventArgs() 
                {
                    TicketId = Id, 
                    OldState = CurrentState, 
                    NewState = value
                });
                CurrentState = value;
            } 
        }
        public TicketPriority Priority { get; set; }
        public virtual SpaceUser Creator { get; set; }
        public int CreatorId { get; set; }
        public virtual SpaceUser AssignedTo { get; set; }
        public int AssignedToId { get; set; }
        public ICollection<Ticket> SubTasks { get; } = new List<Ticket>();

        public event EventHandler<TicketStateChangedEventArgs> TicketStateChanged;

        public virtual void OnTicketStateChanged (object sender, TicketStateChangedEventArgs eventArgs)
        {
            var handler = TicketStateChanged;

            if (handler != null )
            {
                handler(this, eventArgs);
            }
        }

        public enum State
        {
            FREE, IN_PROGRESS, COMPLETED, ON_REVIEW, FINISHED
        }
    }
}