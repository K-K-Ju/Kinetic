using System;

namespace Kinetic.Core.Entities.Space.BackLog
{
    public class Log
    {
        public int Id { get; set; }
        public int InitiatorId { get; set; }
        public DateTime When { get; set; } = DateTime.UtcNow;
    }
}
