using Kinetic.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kinetic.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly KineticDbContext _dbContext;

        public UserController(KineticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize]
        public IActionResult Index()
        {
            string userId = HttpContext.User.FindFirst(c => c.ValueType == "user_id").Value;

            var user = _dbContext.Users
                .Where(u => u.Id == int.Parse(userId))
                .Single();

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
