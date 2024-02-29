namespace Kinetic.Core.Entities.Space
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        private State _currentState = State.FREE;
        public State CurrentState {
            get { return _currentState; }
            set 
            {
                OnTicketStateChanged(this, new TicketStateChangedEventArgs()
                {
                    InitiatorId = AssignedToId,
                    TicketId = Id, 
                    OldState = CurrentState, 
                    NewState = value
                });
                _currentState = value;
            } 
        }
        public TicketPriority Priority { get; set; }
        public virtual SpaceUser Creator { get; set; }
        public int CreatorId { get; set; }
        public virtual SpaceUser? AssignedTo { get; set; }
        public int AssignedToId { get; set; }
        public ICollection<Ticket> SubTasks { get; } = new List<Ticket>();
        public ICollection<Tag> Tags { get; } = new List<Tag>();

        public event EventHandler<TicketStateChangedEventArgs> TicketStateChanged;

        private void OnTicketStateChanged (object sender, TicketStateChangedEventArgs eventArgs)
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