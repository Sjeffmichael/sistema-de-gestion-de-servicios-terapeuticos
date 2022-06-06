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
    public class MasajistaControler : ControllerBase
    {
        private readonly nancurunaisadbContext _context;

        public MasajistaControler(nancurunaisadbContext context)
        {
            _context = context;
        }

        // GET: api/MasajistaControler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<masajista>>> Getmasajista()
        {
          if (_context.masajista == null)
          {
              return NotFound();
          }
            return await _context.masajista.ToListAsync();
        }

        // GET: api/MasajistaControler/5
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

        // PUT: api/MasajistaControler/5
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

        // POST: api/MasajistaControler
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<masajista>> Postmasajista(masajista masajista)
        {
          if (_context.masajista == null)
          {
              return Problem("Entity set 'nancurunaisadbContext.masajista'  is null.");
          }
            _context.masajista.Add(masajista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmasajista", new { id = masajista.idMasajista }, masajista);
        }

        // DELETE: api/MasajistaControler/5
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
    }
}
