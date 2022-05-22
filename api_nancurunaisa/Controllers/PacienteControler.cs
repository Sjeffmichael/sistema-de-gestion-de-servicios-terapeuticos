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
    public class PacienteControler : ControllerBase
    {
        private readonly nancurunaisadbContext _context;

        public PacienteControler(nancurunaisadbContext context)
        {
            _context = context;
        }

        // GET: api/PacienteControler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<paciente>>> Getpaciente()
        {
          if (_context.paciente == null)
          {
              return NotFound();
          }
            return await _context.paciente.ToListAsync();
        }

        // GET: api/PacienteControler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<paciente>> Getpaciente(int id)
        {
          if (_context.paciente == null)
          {
              return NotFound();
          }
            var paciente = await _context.paciente.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }

        // PUT: api/PacienteControler/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpaciente(int id, paciente paciente)
        {
            if (id != paciente.idPaciente)
            {
                return BadRequest();
            }

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pacienteExists(id))
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

        // POST: api/PacienteControler
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<paciente>> Postpaciente(paciente paciente)
        {
          if (_context.paciente == null)
          {
              return Problem("Entity set 'nancurunaisadbContext.paciente'  is null.");
          }
            _context.paciente.Add(paciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpaciente", new { id = paciente.idPaciente }, paciente);
        }

        // DELETE: api/PacienteControler/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepaciente(int id)
        {
            if (_context.paciente == null)
            {
                return NotFound();
            }
            var paciente = await _context.paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.paciente.Remove(paciente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool pacienteExists(int id)
        {
            return (_context.paciente?.Any(e => e.idPaciente == id)).GetValueOrDefault();
        }
    }
}
