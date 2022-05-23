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
    public class VehiculosController : ControllerBase
    {
        private readonly RentCarContext _context;

        public VehiculosController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/Vehiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculo()
        {
          if (_context.Vehiculo == null)
          {
              return NotFound();
          }
            return await _context.Vehiculo.ToListAsync();
        }

        // GET: api/Vehiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
        {
          if (_context.Vehiculo == null)
          {
              return NotFound();
          }
            var Vehiculo = await _context.Vehiculo.FindAsync(id);

            if (Vehiculo == null)
            {
                return NotFound();
            }

            return Vehiculo;
        }

        // PUT: api/Vehiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculo(int id, Vehiculo Vehiculo)
        {
            if (id != Vehiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(Vehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
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

        // POST: api/Vehiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo Vehiculo)
        {
          if (_context.Vehiculo == null)
          {
              return Problem("Entity set 'RentCarContext.Vehiculo'  is null.");
          }
            _context.Vehiculo.Add(Vehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculo", new { id = Vehiculo.Id }, Vehiculo);
        }

        // DELETE: api/Vehiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            if (_context.Vehiculo == null)
            {
                return NotFound();
            }
            var Vehiculo = await _context.Vehiculo.FindAsync(id);
            if (Vehiculo == null)
            {
                return NotFound();
            }

            _context.Vehiculo.Remove(Vehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoExists(int id)
        {
            return (_context.Vehiculo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
