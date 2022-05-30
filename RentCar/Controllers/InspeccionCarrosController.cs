using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentCar.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.Models;

namespace RentCar.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InspeccionCarrosController : ControllerBase
    {
        private readonly RentCarContext _context;

        public InspeccionCarrosController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/InspeccionCarros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspeccionCarro>>> GetInspeccionCarro()
        {
          if (_context.InspeccionCarro == null)
          {
              return NotFound();
          }
            return await _context.InspeccionCarro.ToListAsync();
        }

        // GET: api/InspeccionCarros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspeccionCarro>> GetInspeccionCarro(int id)
        {
          if (_context.InspeccionCarro == null)
          {
              return NotFound();
          }
            var InspeccionCarro = await _context.InspeccionCarro.FindAsync(id);

            if (InspeccionCarro == null)
            {
                return NotFound();
            }

            return InspeccionCarro;
        }

        // PUT: api/InspeccionCarros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspeccionCarro(int id, InspeccionCarro InspeccionCarro)
        {
            if (id != InspeccionCarro.Id)
            {
                return BadRequest();
            }

            _context.Entry(InspeccionCarro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspeccionCarroExists(id))
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

        // POST: api/InspeccionCarros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InspeccionCarro>> PostInspeccionCarro(InspeccionCarro InspeccionCarro)
        {
          if (_context.InspeccionCarro == null)
          {
              return Problem("Entity set 'RentCarContext.InspeccionCarro'  is null.");
          }
            _context.InspeccionCarro.Add(InspeccionCarro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspeccionCarro", new { id = InspeccionCarro.Id }, InspeccionCarro);
        }

        // DELETE: api/InspeccionCarros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspeccionCarro(int id)
        {
            if (_context.InspeccionCarro == null)
            {
                return NotFound();
            }
            var InspeccionCarro = await _context.InspeccionCarro.FindAsync(id);
            if (InspeccionCarro == null)
            {
                return NotFound();
            }

            _context.InspeccionCarro.Remove(InspeccionCarro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InspeccionCarroExists(int id)
        {
            return (_context.InspeccionCarro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
