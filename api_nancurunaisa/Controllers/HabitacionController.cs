using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_nancurunaisa.Models;

namespace api_nancurunaisa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly nancurunaisadbContext _context;

        public HabitacionController(nancurunaisadbContext context)
        {
            _context = context;
        }

        // GET: api/Habitacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<habitacion>>> Gethabitacion(int idSucursal, int Page, int PerPage)
        {
          if (_context.habitacion == null)
          {
              return NotFound();
          }

            var pageResult = (float)PerPage;
            var pageCount = Math.Ceiling(_context.habitacion.Count() / (float)PerPage);

            var habitacionesResults = await _context.habitacion.Where(h => h.idSucursal == idSucursal)
                  .Skip((Page - 1) * PerPage)
                  .Take((int)pageResult)
                  .ToListAsync();

            var response = new HabitacionPaginationResponse
            {
                habitaciones = habitacionesResults,
                currentPage = Page,
                pages = (int)pageCount
            };

            return Ok(response);
        }

        // GET: api/Habitacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<habitacion>> Gethabitacion(int id)
        {
          if (_context.habitacion == null)
          {
              return NotFound();
          }
            var habitacion = await _context.habitacion.FindAsync(id);

            if (habitacion == null)
            {
                return NotFound();
            }

            return habitacion;
        }

        // PUT: api/Habitacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puthabitacion(int id, habitacion habitacion)
        {
            if (id != habitacion.idHabitacion)
            {
                return BadRequest();
            }

            _context.Entry(habitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!habitacionExists(id))
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

        // POST: api/Habitacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<habitacion>> Posthabitacion(habitacion habitacion)
        {
          if (_context.habitacion == null)
          {
              return Problem("Entity set 'nancurunaisadbContext.habitacion'  is null.");
          }
            _context.habitacion.Add(habitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gethabitacion", new { id = habitacion.idHabitacion }, habitacion);
        }

        // DELETE: api/Habitacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletehabitacion(int id)
        {
            if (_context.habitacion == null)
            {
                return NotFound();
            }
            var habitacion = await _context.habitacion.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            _context.habitacion.Remove(habitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool habitacionExists(int id)
        {
            return (_context.habitacion?.Any(e => e.idHabitacion == id)).GetValueOrDefault();
        }
    }
}
