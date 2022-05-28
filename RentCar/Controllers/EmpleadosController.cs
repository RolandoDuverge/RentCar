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
    public class EmpleadosController : ControllerBase
    {
        private readonly RentCarContext _context;

        public EmpleadosController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleados>>> GetEmpleados()
        {
          if (_context.Empleados == null)
          {
              return NotFound();
          }
            return await _context.Empleados.ToListAsync();
        }

        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleados>> GetEmpleados(int id)
        {
          if (_context.Empleados == null)
          {
              return NotFound();
          }
            var Empleados = await _context.Empleados.FindAsync(id);

            if (Empleados == null)
            {
                return NotFound();
            }

            return Empleados;
        }

        // PUT: api/Empleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleados(int id, Empleados Empleados)
        {
            if (id != Empleados.Id)
            {
                return BadRequest();
            }

            _context.Entry(Empleados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosExists(id))
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

        // POST: api/Empleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleados>> PostEmpleados(Empleados Empleados)
        {
          if (_context.Empleados == null)
          {
              return Problem("Entity set 'RentCarContext.Empleados'  is null.");
          }
            _context.Empleados.Add(Empleados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleados", new { id = Empleados.Id }, Empleados);
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleados(int id)
        {
            if (_context.Empleados == null)
            {
                return NotFound();
            }
            var Empleados = await _context.Empleados.FindAsync(id);
            if (Empleados == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(Empleados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadosExists(int id)
        {
            return (_context.Empleados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
