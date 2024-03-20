using Kinetic.Application.Abstraction;
using Kinetic.Core.Entities;
using Kinetic.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kinetic.Application.Services
{
    public class UserService : IUserService
    {
        private readonly KineticDbContext _dbContext;
        private readonly ILogger<UserService> _logger;

        public UserService(KineticDbContext dbContext, ILogger<UserService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public User GetCurrentUser(HttpContext context)
        {
            _logger.LogDebug("Retreieving current authenticated user.");

            var userEmail = context.User
                .FindFirstValue(ClaimTypes.Email);

            return (from user in _dbContext.Users
                    where user.Email == userEmail
                    select user)
            .Single();
        }
    }
}
