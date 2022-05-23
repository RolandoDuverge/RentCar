using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.Models;

namespace RentCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCombustiblesController : ControllerBase
    {
        private readonly RentCarContext _context;

        public TipoCombustiblesController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/TipoCombustibles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCombustible>>> GetTipoCombustible()
        {
          if (_context.TipoCombustible == null)
          {
              return NotFound();
          }
            return await _context.TipoCombustible.ToListAsync();
        }

        // GET: api/TipoCombustibles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCombustible>> GetTipoCombustible(int id)
        {
          if (_context.TipoCombustible == null)
          {
              return NotFound();
          }
            var TipoCombustible = await _context.TipoCombustible.FindAsync(id);

            if (TipoCombustible == null)
            {
                return NotFound();
            }

            return TipoCombustible;
        }

        // PUT: api/TipoCombustibles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCombustible(int id, TipoCombustible TipoCombustible)
        {
            if (id != TipoCombustible.Id)
            {
                return BadRequest();
            }

            _context.Entry(TipoCombustible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCombustibleExists(id))
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

        // POST: api/TipoCombustibles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoCombustible>> PostTipoCombustible(TipoCombustible TipoCombustible)
        {
          if (_context.TipoCombustible == null)
          {
              return Problem("Entity set 'RentCarContext.TipoCombustible'  is null.");
          }
            _context.TipoCombustible.Add(TipoCombustible);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoCombustible", new { id = TipoCombustible.Id }, TipoCombustible);
        }

        // DELETE: api/TipoCombustibles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoCombustible(int id)
        {
            if (_context.TipoCombustible == null)
            {
                return NotFound();
            }
            var TipoCombustible = await _context.TipoCombustible.FindAsync(id);
            if (TipoCombustible == null)
            {
                return NotFound();
            }

            _context.TipoCombustible.Remove(TipoCombustible);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoCombustibleExists(int id)
        {
            return (_context.TipoCombustible?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
