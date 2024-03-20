using Kinetic.Application.DTO;
using Kinetic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinetic.Application.Abstraction
{
    public interface ISpaceService
    {
        Task<bool> CreateSpace(SpaceDTO spaceDTO, User creator);
    }
}
