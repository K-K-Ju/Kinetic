using Kinetic.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kinetic.WebUI.ViewComponents
{
    public class TicketListViewComponent : ViewComponent
    {
        public readonly KineticDbContext _dbContext;

        public TicketListViewComponent(KineticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(int SpaceId)
        {
            var tickets = _dbContext.Spaces
                .Where(s => s.Id == SpaceId)
                .Single()
                .Tickets
                .ToList();

            return View(tickets);
        }
    }
}
