using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RentCar.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.Models;

namespace RentCar.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RentaCarrosController : ControllerBase
    {
        private readonly RentCarContext _context;

        public RentaCarrosController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/RentaCarros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentaCarro>>> GetRentaCarro()
        {
          if (_context.RentaCarro == null)
          {
              return NotFound();
          }
            return await _context.RentaCarro.ToListAsync();
        }

        // GET: api/RentaCarros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentaCarro>> GetRentaCarro(int id)
        {
          if (_context.RentaCarro == null)
          {
              return NotFound();
          }
            var RentaCarro = await _context.RentaCarro.FindAsync(id);

            if (RentaCarro == null)
            {
                return NotFound();
            }

            return RentaCarro;
        }

        // PUT: api/RentaCarros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentaCarro(int id, RentaCarro RentaCarro)
        {
            if (id != RentaCarro.Id)
            {
                return BadRequest();
            }

            _context.Entry(RentaCarro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentaCarroExists(id))
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

        // POST: api/RentaCarros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RentaCarro>> PostRentaCarro(RentaCarro RentaCarro)
        {
          if (_context.RentaCarro == null)
          {
              return Problem("Entity set 'RentCarContext.RentaCarro'  is null.");
          }
            _context.RentaCarro.Add(RentaCarro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRentaCarro", new { id = RentaCarro.Id }, RentaCarro);
        }

        // DELETE: api/RentaCarros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentaCarro(int id)
        {
            if (_context.RentaCarro == null)
            {
                return NotFound();
            }
            var RentaCarro = await _context.RentaCarro.FindAsync(id);
            if (RentaCarro == null)
            {
                return NotFound();
            }

            _context.RentaCarro.Remove(RentaCarro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentaCarroExists(int id)
        {
            return (_context.RentaCarro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
