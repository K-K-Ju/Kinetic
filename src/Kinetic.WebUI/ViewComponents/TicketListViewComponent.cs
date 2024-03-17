using AutoMapper;
using Kinetic.Application.DTO;
using Kinetic.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Kinetic.WebUI.ViewComponents
{
    public class TicketListViewComponent : ViewComponent
    {
        public readonly KineticDbContext _dbContext;
        public readonly IMapper _mapper;

        public TicketListViewComponent(KineticDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int SpaceId)
        {
            var tickets = _dbContext.Tickets
                .Where(t => t.SpaceId == SpaceId)
                .ToList();

            var ticketDTOs = _mapper.Map<List<TicketDTO>>(tickets);

            return View(tickets);
        }
    }
}
