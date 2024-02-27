using System;

namespace Kinetic.Core.Entities.Space.BackLog
{
    public abstract class Log
    {
        public virtual SpaceUser Initiator { get; set; }
        public int InitiatorId { get; set; }
        public DateTime When { get; set; } = DateTime.UtcNow;
    }
}
