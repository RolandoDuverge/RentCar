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
    public class TipoVehiculosController : ControllerBase
    {
        private readonly RentCarContext _context;

        public TipoVehiculosController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/TipoVehiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoVehiculo>>> GetTipoVehiculo()
        {
          if (_context.TipoVehiculo == null)
          {
              return NotFound();
          }
            return await _context.TipoVehiculo.ToListAsync();
        }

        // GET: api/TipoVehiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVehiculo>> GetTipoVehiculo(int id)
        {
          if (_context.TipoVehiculo == null)
          {
              return NotFound();
          }
            var TipoVehiculo = await _context.TipoVehiculo.FindAsync(id);

            if (TipoVehiculo == null)
            {
                return NotFound();
            }

            return TipoVehiculo;
        }

        // PUT: api/TipoVehiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoVehiculo(int id, TipoVehiculo TipoVehiculo)
        {
            if (id != TipoVehiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(TipoVehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoVehiculoExists(id))
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

        // POST: api/TipoVehiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoVehiculo>> PostTipoVehiculo(TipoVehiculo TipoVehiculo)
        {
          if (_context.TipoVehiculo == null)
          {
              return Problem("Entity set 'RentCarContext.TipoVehiculo'  is null.");
          }
            _context.TipoVehiculo.Add(TipoVehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoVehiculo", new { id = TipoVehiculo.Id }, TipoVehiculo);
        }

        // DELETE: api/TipoVehiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoVehiculo(int id)
        {
            if (_context.TipoVehiculo == null)
            {
                return NotFound();
            }
            var TipoVehiculo = await _context.TipoVehiculo.FindAsync(id);
            if (TipoVehiculo == null)
            {
                return NotFound();
            }

            _context.TipoVehiculo.Remove(TipoVehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoVehiculoExists(int id)
        {
            return (_context.TipoVehiculo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
