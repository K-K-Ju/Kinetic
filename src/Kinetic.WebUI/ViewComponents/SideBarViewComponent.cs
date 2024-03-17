using AutoMapper;
using Kinetic.Application.Abstraction;
using Kinetic.Application.DTO;
using Kinetic.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace Kinetic.WebUI.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly KineticDbContext _dbContext;
        private readonly ILogger<SideBarViewComponent> _logger;
        private readonly IUserService _userService;

        public SideBarViewComponent(
            KineticDbContext dbContext, 
            ILogger<SideBarViewComponent> logger, 
            IUserService userService)
        {
            _dbContext = dbContext;
            _logger = logger;
            _userService = userService;
        }

        [Authorize]
        public IViewComponentResult Invoke()
        {
            var user = _userService.GetCurrentUser(HttpContext);
            if (user == null)
            {
                return View("Views/Shared/Error");
                //// TODO: error
            }

            var spaces = _dbContext.Spaces
                .Where(s => s.OwnerId == user.Id || s.SpaceUsers.All(su => su.Id == user.Id))
                .Select(s => new { s.Name, s.Id });

            var spaceDTOs = new List<SpaceDTO>();

            foreach (var spaceNameId in spaces)
            {
                spaceDTOs.Add(new SpaceDTO() { Name = spaceNameId.Name, Id = spaceNameId.Id });
            }

            return View(spaceDTOs);
        }
    }
}
