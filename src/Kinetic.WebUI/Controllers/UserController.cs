using Kinetic.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kinetic.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly KineticDbContext _dbContext;
        private readonly ILogger<UserController> _logger;

        public UserController(KineticDbContext dbContext, ILogger<UserController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            string identityUserEmail = HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.Email)
                .First()
                .Value;

            if (identityUserEmail == null)
            {
                _logger.LogError("HttpContext.User can't have claim with null value of type ClaimTypes.Email");
                return View("Error");
            }

            var user = _dbContext.Users
                .Where(u => u.Email == identityUserEmail)
                .FirstOrDefault();

            return View(user);
        }

        [Authorize]
        public IActionResult EditGet()
        {
            return View();
        }

        [Authorize]
        public IActionResult EditPost(string firstName, string lastName)
        {
            var userId = HttpContext.Session.GetInt32("user_id");

            var user = _dbContext.Users
                .Where(u => u.Id == userId)
                .Single();

            user.FirstName = firstName;
            user.LastName = lastName;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
