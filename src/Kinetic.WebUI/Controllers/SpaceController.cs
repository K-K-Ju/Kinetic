using Microsoft.AspNetCore.Mvc;

namespace Kinetic.WebUI.Controllers
{
    public class SpaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
