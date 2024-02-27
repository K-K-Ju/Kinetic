using System.Collections.Generic;

namespace Kinetic.Core.Entities.Space
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<Restriction> Restrictions { get; } = new List<Restriction>();
    }
}