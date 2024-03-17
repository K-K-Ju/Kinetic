using Kinetic.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinetic.Application.Abstraction
{
    public interface ISpaceService
    {
        Task<bool> CreateSpace(SpaceDTO spaceDTO);
    }
}
