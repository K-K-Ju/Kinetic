using Kinetic.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Kinetic.WebUI.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly KineticDbContext _dbContext;

        public SideBarViewComponent(KineticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
