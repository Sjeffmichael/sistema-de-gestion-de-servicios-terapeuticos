using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_nancurunaisa.Models;
using api_nancurunaisa.Utilities;

namespace api_nancurunaisa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasajistaController : ControllerBase
    {
        private readonly nancurunaisadbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MasajistaController(nancurunaisadbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/Masajista
        [HttpGet]
        public async Task<ActionResult<IEnumerable<masajista>>> Getmasajista(int Page, int PerPage, string? nombreMasajista = "")
        {
          if (_context.masajista == null)
          {
              return NotFound();
          }
            var pageResult = (float)PerPage;
            var pageCount = Math.Ceiling(_context.masajista.Where(t => t.nombres.Contains(nombreMasajista)).Count() / (float)PerPage);

            var masajistasResults = await _context.masajista.Where(t => t.nombres.Contains(nombreMasajista)).Include(x => x.idDia)
                  .Skip((Page - 1) * PerPage)
                  .Take((int)pageResult)
                  .ToListAsync();

            var response = new MasajistaPaginationResponse
            {
                masajistas = masajistasResults,
                currentPage = Page,
                pages = (int)pageCount
            };

            return Ok(response);
        }

        // GET: api/Masajista/5
        [HttpGet("{id}")]
        public async Task<ActionResult<masajista>> Getmasajista(int id)
        {
          if (_context.masajista == null)
          {
              return NotFound();
          }
            var masajista = await _context.masajista.FindAsync(id);

            if (masajista == null)
            {
                return NotFound();
            }

            return masajista;
        }

        // PUT: api/Masajista/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmasajista(int id, masajista masajista)
        {
            if (id != masajista.idMasajista)
            {
                return BadRequest();
            }

            _context.Entry(masajista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!masajistaExists(id))
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

        // POST: api/Masajista
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<masajista>> Postmasajista([FromForm]masajista masajista)
        {

          if (_context.masajista == null)
          {
              return Problem("Entity set 'nancurunaisadbContext.masajista'  is null.");
          }

            masajista.foto = await SaveImage(masajista.fotoPerfil);

            _context.masajista.Add(masajista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmasajista", new { id = masajista.idMasajista }, masajista);
        }

        // DELETE: api/Masajista/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemasajista(int id)
        {
            if (_context.masajista == null)
            {
                return NotFound();
            }
            var masajista = await _context.masajista.FindAsync(id);
            if (masajista == null)
            {
                return NotFound();
            }

            _context.masajista.Remove(masajista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool masajistaExists(int id)
        {
            return (_context.masajista?.Any(e => e.idMasajista == id)).GetValueOrDefault();
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
