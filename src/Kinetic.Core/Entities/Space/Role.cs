using System.Collections.Generic;
using Kinetic.Core.Entities.Space.Restritions;

namespace Kinetic.Core.Entities.Space
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Restriction> Restrictions { get; } = new List<Restriction>();
    }
}