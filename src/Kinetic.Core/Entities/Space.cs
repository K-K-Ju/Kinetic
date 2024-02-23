using System;
using System.Collections;
using System.Collections.Generic;

namespace Kinetic.Core.Entities
{
    public class Space
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual User Owner { get; set; }

        public ICollection<Task> Tasks { get; set; }
        public ICollection<Role> Roles { get; set; }
        public IDictionary<User, Role> UserRoles { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}