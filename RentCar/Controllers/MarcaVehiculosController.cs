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
    public class MarcaVehiculosController : ControllerBase
    {
        private readonly RentCarContext _context;

        public MarcaVehiculosController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/MarcaVehiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaVehiculo>>> GetMarcaVehiculo()
        {
          if (_context.MarcaVehiculo == null)
          {
              return NotFound();
          }
            return await _context.MarcaVehiculo.ToListAsync();
        }

        // GET: api/MarcaVehiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarcaVehiculo>> GetMarcaVehiculo(int id)
        {
          if (_context.MarcaVehiculo == null)
          {
              return NotFound();
          }
            var MarcaVehiculo = await _context.MarcaVehiculo.FindAsync(id);

            if (MarcaVehiculo == null)
            {
                return NotFound();
            }

            return MarcaVehiculo;
        }

        // PUT: api/MarcaVehiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarcaVehiculo(int id, MarcaVehiculo MarcaVehiculo)
        {
            if (id != MarcaVehiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(MarcaVehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaVehiculoExists(id))
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

        // POST: api/MarcaVehiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MarcaVehiculo>> PostMarcaVehiculo(MarcaVehiculo MarcaVehiculo)
        {
          if (_context.MarcaVehiculo == null)
          {
              return Problem("Entity set 'RentCarContext.MarcaVehiculo'  is null.");
          }
            _context.MarcaVehiculo.Add(MarcaVehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarcaVehiculo", new { id = MarcaVehiculo.Id }, MarcaVehiculo);
        }

        // DELETE: api/MarcaVehiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarcaVehiculo(int id)
        {
            if (_context.MarcaVehiculo == null)
            {
                return NotFound();
            }
            var MarcaVehiculo = await _context.MarcaVehiculo.FindAsync(id);
            if (MarcaVehiculo == null)
            {
                return NotFound();
            }

            _context.MarcaVehiculo.Remove(MarcaVehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarcaVehiculoExists(int id)
        {
            return (_context.MarcaVehiculo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
