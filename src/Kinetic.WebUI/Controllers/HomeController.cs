using Kinetic.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kinetic.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private KineticDbContext _dbContext;
        
        public HomeController(KineticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: IndexController
        public ActionResult Index()
        {
            var users = _dbContext.Users.OrderBy(u => u.FirstName).ToList();
            //ViewData["Users"] = users;
            return View(users);
        }

        // GET: IndexController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IndexController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndexController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndexController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndexController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndexController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndexController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
