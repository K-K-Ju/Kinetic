using Kinetic.Infrastructure.Data;
using Kinetic.WebUI.ViewComponents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kinetic.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly KineticDbContext _dbContext;
        
        public HomeController(KineticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: IndexController
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
