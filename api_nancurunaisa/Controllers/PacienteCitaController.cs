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
    public class PacienteCitaController : ControllerBase
    {
        private readonly nancurunaisadbContext _context;

        public PacienteCitaController(nancurunaisadbContext context)
        {
            _context = context;
        }

        // GET: api/PacienteCita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<pacienteCita>>> GetpacienteCita()
        {
          if (_context.pacienteCita == null)
          {
              return NotFound();
          }
            return await _context.pacienteCita.ToListAsync();
        }

        // GET: api/PacienteCita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<pacienteCita>> GetpacienteCita(int idPaciente, int idCita)
        {
          if (_context.pacienteCita == null)
          {
              return NotFound();
          }
            var pacienteCita = await _context.pacienteCita.FindAsync(idPaciente, idCita);

            if (pacienteCita == null)
            {
                return NotFound();
            }

            return pacienteCita;
        }

        // PUT: api/PacienteCita/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutpacienteCita(int id, pacienteCita pacienteCita)
        {
            if (id != pacienteCita.idCita)
            {
                return BadRequest();
            }

            _context.Entry(pacienteCita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pacienteCitaExists(id))
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

        // POST: api/PacienteCita
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<pacienteCita>> PostpacienteCita(pacienteCita pacienteCita)
        {
          if (_context.pacienteCita == null)
          {
              return Problem("Entity set 'nancurunaisadbContext.pacienteCita'  is null.");
          }
            _context.pacienteCita.Add(pacienteCita);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (pacienteCitaExists(pacienteCita.idCita))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetpacienteCita", new { id = pacienteCita.idCita }, pacienteCita);
        }

        // DELETE: api/PacienteCita/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletepacienteCita(int id)
        {
            if (_context.pacienteCita == null)
            {
                return NotFound();
            }
            var pacienteCita = await _context.pacienteCita.FindAsync(id);
            if (pacienteCita == null)
            {
                return NotFound();
            }

            _context.pacienteCita.Remove(pacienteCita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool pacienteCitaExists(int id)
        {
            return (_context.pacienteCita?.Any(e => e.idCita == id)).GetValueOrDefault();
        }
    }
}
