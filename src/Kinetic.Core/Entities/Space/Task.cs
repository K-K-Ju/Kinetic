using System;
using System.Collections;
using System.Collections.Generic;

namespace Kinetic.Core.Entities.Space
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public State CurrentState { get; set; }
        public virtual User Creator { get; set; }
        public virtual User AssignedTo { get; set; }
        public IDictionary<State, DateTime> States { get; set; } ///TODO: optimize

        public enum State
        {
            FREE, IN_PROGRESS, COMPLETED, ON_REVIEW, FINISHED
        }
    }
}