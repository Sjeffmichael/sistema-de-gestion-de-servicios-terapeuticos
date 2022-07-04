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
    public class PacienteController : ControllerBase
    {
        private readonly nancurunaisadbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PacienteController(nancurunaisadbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: api/Paciente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<paciente>>> Getpaciente(int Page, int PerPage, string? nombrePaciente="")
        {
          if (_context.paciente == null)
          {
              return NotFound();
          }
            var pageResult = (float)PerPage;
            var pageCount = Math.Ceiling(_context.paciente.Where(t => t.nombres.Contains(nombrePaciente)).Count() / (float)PerPage);

            var pacientesResults = await _context.paciente.Where(t => t.nombres.Contains(nombrePaciente)).Include(x => x.amnanesis)
                  .Skip((Page - 1) * PerPage)
                  .Take((int)pageResult)
                  .ToListAsync();

            var response = new PacientePaginationResponse
            {
                pacientes = pacientesResults,
                currentPage = Page,
                pages = (int)pageCount
            };
            return Ok(response);
        }

        // GET: api/Paciente/5
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

        // PUT: api/Paciente/5
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

        // POST: api/Paciente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<paciente>> Postpaciente([FromForm]paciente paciente)
        {
          if (_context.paciente == null)
          {
              return Problem("Entity set 'nancurunaisadbContext.paciente'  is null.");
          }

            _context.paciente.Add(paciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpaciente", new { id = paciente.idPaciente }, paciente);
        }

        // DELETE: api/Paciente/5
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

        [NonAction]
        public async Task<string> SaveImage(IFormFile fotoPerfil)
        {
            string nombreFoto = new String(Path.GetFileNameWithoutExtension(fotoPerfil.Name).Take(10).ToArray()).Replace(' ', '-');
            nombreFoto = nombreFoto + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(fotoPerfil.FileName);
            var rutaFoto = Path.Combine(_hostEnvironment.ContentRootPath, "Images", nombreFoto);

            using (var fileStream = new FileStream(rutaFoto, FileMode.Create))
            {
                await fotoPerfil.CopyToAsync(fileStream);
            }

            return nombreFoto;
        }
    }
}
