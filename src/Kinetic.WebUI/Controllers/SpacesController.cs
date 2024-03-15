using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kinetic.Core.Entities.Space;
using Kinetic.Infrastructure.Data;
using AutoMapper;
using Kinetic.Application.TicketService.DTO;
using Kinetic.Application.SpaceService.DTO;

namespace Kinetic.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpacesController : ControllerBase
    {
        private readonly KineticDbContext _context;
        private readonly IMapper _mapper;

        public SpacesController(KineticDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Spaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpaceDTO>>> GetSpaces()
        {
            var spaces = await _context.Spaces.ToListAsync();
            var spaceDTOs = _mapper.Map<List<Space>, List<SpaceDTO>>(spaces);

            return Ok(spaceDTOs);
        }

        // GET: api/Spaces/5
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

        // POST: api/Spaces
        [HttpPost]
        public async Task<ActionResult<Space>> PostSpace(SpaceDTO spaceDTO)
        {
            var space = _mapper.Map<Space>(spaceDTO);
            _context.Spaces.Add(space);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSpaces), new { id = space.Id }, space);
        }

        // DELETE: api/Spaces/5
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
