using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kinetic.Core.Entities.Space;
using Kinetic.Infrastructure.Data;
using AutoMapper;
using Kinetic.Application.DTO;
using Kinetic.Application.Abstraction;
using Microsoft.AspNetCore.Authorization;

namespace Kinetic.WebUI.Controllers
{
    [Route("space/")]
    [ApiController]
    [Authorize]
    public class SpacesController : Controller
    {
        private readonly KineticDbContext _context;
        private readonly ISpaceService _spaceService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public SpacesController(KineticDbContext context, ISpaceService spaceService, IUserService userService, IMapper mapper)
        {
            _context = context;
            _spaceService = spaceService;
            _userService = userService;
            _mapper = mapper;
        }

        // GET: spaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpaceDTO>>> GetSpaces()
        {
            var spaces = await _context.Spaces.ToListAsync();
            var spaceDTOs = _mapper.Map<List<Space>, List<SpaceDTO>>(spaces);

            return Ok(spaceDTOs);
        }

        // GET: space/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpaceDTO>> GetSpace(int id)
        {
            var space = await _context.Spaces.FindAsync(id);

            if (space == null)
            {
                return NotFound();
            }

            return _mapper.Map<SpaceDTO>(space);
        }

        // GET: space/5/tickets
        [HttpGet("{id}/tickets")]
        public ActionResult<List<TicketDTO>> GetSpaceTickets(int id)
        {
            return ViewComponent("TicketList", id);
        }

        // POST: space/create
        [HttpGet("create")]
        public ActionResult CreateSpace()
        {
            return View("Create");
        }

        [HttpPost("create")]
        public async Task<bool> PostSpace([FromForm]string spaceName)
        {
            return await _spaceService.CreateSpace(new SpaceDTO() { Name = spaceName }, _userService.GetCurrentUser(HttpContext));
        }

        // DELETE: space/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpace(int id)
        {
            var space = await _context.Spaces.FindAsync(id);
            if (space == null)
            {
                return NotFound();
            }

            _context.Spaces.Remove(space);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpaceExists(int id)
        {
            return _context.Spaces.Any(e => e.Id == id);
        }
    }
}
