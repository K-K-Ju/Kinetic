﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kinetic.Core.Entities.Space;
using Kinetic.Infrastructure.Data;
using AutoMapper;
using Kinetic.Application.DTO;

namespace Kinetic.WebUI.Controllers
{
    [Route("tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly KineticDbContext _dbContext;
        private readonly IMapper _mapper;

        public TicketController(KineticDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDTO>> GetTicket(int id)
        {
            var ticket = await _dbContext.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            var ticketDTO = _mapper.Map<TicketDTO>(ticket);
            
            return ticketDTO;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, TicketDTO ticketDTO)
        {
            if (id != ticketDTO.Id)
            {
                return BadRequest();
            }
            
            var ticket = _dbContext.Tickets.Find(id);

            _dbContext.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: tickets/
        [HttpPost]
        public async Task<int> PostTicket(TicketDTO ticketDTO)
        {
            var ticket = _mapper.Map<Ticket>(ticketDTO);
            _dbContext.Tickets.Add(ticket);
            await _dbContext.SaveChangesAsync();

            return 200;
        }
        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _dbContext.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _dbContext.Tickets.Remove(ticket);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketExists(int id)
        {
            return _dbContext.Tickets.Any(e => e.Id == id);
        }
    }
}
