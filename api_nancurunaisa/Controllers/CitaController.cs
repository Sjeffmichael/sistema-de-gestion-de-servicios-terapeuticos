using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_nancurunaisa.Models;
using System.Globalization;

namespace api_nancurunaisa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly nancurunaisadbContext _context;

        public CitaController(nancurunaisadbContext context)
        {
            _context = context;
        }

        // GET: api/Cita
        [HttpGet]
        public async Task<ActionResult<List<cita>[]>> Getcita(string year)
        {
          if (_context.cita == null)
          {
              return NotFound();
          }
            //group the appointments by months of a specific year
            var citas = (from c in await _context.cita.Where(c => c.fechaHora.Year == Convert.ToInt32(year)).ToListAsync()
                         group c by c.fechaHora.Month into nc
                         select nc).ToDictionary(p => p.Key, p => p.ToList());


            //Initialized an array of empty lists of appointments
            List<cita>[] arr = new List<cita>[12].Select(item => new List<cita> { }).ToArray();


            foreach (var c in citas)
            {
                arr[c.Key - 1] = c.Value;
            }

            return arr;
            
        }

        // GET: api/Cita
        //[HttpGet]
        //public async Task<ActionResult<List<cita>[]>> Getcita(string date, int type)
        //{
        //    if (_context.cita == null)
        //    {
        //        return NotFound();
        //    }
        //    //group the appointments by months of a specific year
        //    var citas2 = (from c in await _context.cita
        //                  .Where(
        //                            c => ISOWeek.GetWeekOfYear(c.fechaHora) == ISOWeek.GetWeekOfYear(DateTime.Parse(date))
        //                  ).ToListAsync()
        //                  group c by c.idHabitacion. into nc
        //                  select nc).ToDictionary(p => p.Key, p => p.ToList());


        //    //Initialized an array of empty lists of appointments
        //    List<cita>[] arr = new List<cita>[12].Select(item => new List<cita> { }).ToArray();


        //    foreach (var c in citas2)
        //    {
        //        arr[c.Key - 1] = c.Value;
        //    }

        //    return arr;

        //}

        // GET: api/Cita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<cita>>> Getcita(int id)
        {
          if (_context.cita == null)
          {
              return NotFound();
          }
            var cita = await _context.cita.Where(b => b.idCita == id)
                .Include(c => c.idHabitacionNavigation)
                //.Include(d => d.idHabitacionNavigation.idSucursalNavigation.nombreSucursal)
                .ToListAsync();

            //var cita = from c in await _context.cita.Where(c => c.idCita == id).ToListAsync()
            //            select new cita
            //            {
            //                idCita = c.idCita,
            //                fechaHora = c.fechaHora,
            //                pendiente = c.pendiente,
            //                direccion_domicilio = c.direccion_domicilio,
            //                color = c.color,
            //                nombreHabitacion = c.idHabitacionNavigation.nombreHabitacion,
            //                nombreSucursal = c.idHabitacionNavigation.idSucursalNavigation.nombreSucursal
            //            };

            if (cita == null)
            {
                return NotFound();
            }

            return cita;
        }

        // PUT: api/Cita/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcita(int id, cita cita)
        {
            if (id != cita.idCita)
            {
                return BadRequest();
            }

            _context.Entry(cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!citaExists(id))
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

        // POST: api/Cita
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<cita>> Postcita(cita cita)
        {
          if (_context.cita == null)
          {
              return Problem("Entity set 'nancurunaisadbContext.cita'  is null.");
          }
            _context.cita.Add(cita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcita", new { id = cita.idCita }, cita);
        }

        // DELETE: api/Cita/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecita(int id)
        {
            if (_context.cita == null)
            {
                return NotFound();
            }
            var cita = await _context.cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }

            _context.cita.Remove(cita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<cita>> Getcita(int idMasajista, string fecha)
        //{
        //    //if (_context.cita == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var cita = await _context.cita.FindAsync(idMasajista);

        //    //if (cita == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //return cita;
        //}

        private bool citaExists(int id)
        {
            return (_context.cita?.Any(e => e.idCita == id)).GetValueOrDefault();
        }
    }
}
