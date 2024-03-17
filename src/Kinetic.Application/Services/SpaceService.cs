using AutoMapper;
using Kinetic.Application.Abstraction;
using Kinetic.Application.DTO;
using Kinetic.Core.Entities.Space;
using Kinetic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinetic.Application.Services
{
    public class SpaceService : ISpaceService
    {
        private readonly KineticDbContext _dbContext;
        private readonly IMapper _mapper;

        public SpaceService(KineticDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> CreateSpace(SpaceDTO spaceDTO)
        {
            var space = _mapper.Map<Space>(spaceDTO);
            _dbContext.Spaces.Add(space);
            return await _dbContext.SaveChangesAsync() == 1;
        }

        public async Task<SpaceDTO?> GetSpaceById(int id)
        {
            var space = await _dbContext.Spaces.FindAsync(id);

            return space == null ? null : _mapper.Map<SpaceDTO>(space);
        }
    }
}
