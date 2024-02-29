using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinetic.Core.Entities.Space.BackLog
{
    public class SpaceBackLog
    {
        public int Id { get; set; }
        public Space ParentSpace { get; set; }
        public int SpaceId { get; set; }
        public ICollection<Log> Logs { get; } = new List<Log>();
    }
}
