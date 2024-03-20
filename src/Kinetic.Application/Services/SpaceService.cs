using AutoMapper;
using Kinetic.Application.Abstraction;
using Kinetic.Application.DTO;
using Kinetic.Core.Entities;
using Kinetic.Core.Entities.Space;
using Kinetic.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Kinetic.Application.Services
{
    public class SpaceService : ISpaceService
    {
        private readonly KineticDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<SpaceService> _logger;


        public SpaceService(
            KineticDbContext dbContext,
            IMapper mapper,
            ILogger<SpaceService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> CreateSpace(SpaceDTO spaceDTO, User creator)
        {

            var space = _mapper.Map<Space>(spaceDTO);
            space.SpaceBackLog = new Core.Entities.Space.BackLog.SpaceBackLog();
            space.Owner = creator;
            space.OwnerId = creator.Id;

            var transaction = _dbContext.Database.BeginTransaction();

            _dbContext.Spaces.Add(space);
            
            var role = new Role() { Name = "No role" };
            _dbContext.Roles.Add(role);
            space.Roles.Add(role);

            var spaceUser = new SpaceUser()
            {
                User = creator,
                Space = space,
                SpaceId = space.Id,
                SpaceUserRole = role,
                SpaceUserRoleId = role.Id,
            };

            _dbContext.SpaceUsers.Add(spaceUser);

            await _dbContext.SaveChangesAsync();

            try
            {
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError("Failed to create space\n{msg}", ex.Message);
                return false;
            }
        }

        public async Task<SpaceDTO?> GetSpaceById(int id)
        {
            var space = await _dbContext.Spaces.FindAsync(id);

            return space == null ? null : _mapper.Map<SpaceDTO>(space);
        }
    }
}
