﻿using System.Collections.Generic;

namespace Kinetic.Core.Entities.Space
{
    public abstract class Restriction
    {
        public ICollection<TicketAction> RestrictedTicketActions { get; set; } = new List<TicketAction>();
    }
}