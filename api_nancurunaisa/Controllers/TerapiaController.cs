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
    public class TerapiaController : ControllerBase
    {
        private readonly nancurunaisadbContext _context;

        public TerapiaController(nancurunaisadbContext context)
        {
            _context = context;
        }

        // GET: api/Terapia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<terapia>>> Getterapia()
        {
          if (_context.terapia == null)
          {
              return NotFound();
          }
            return await _context.terapia.ToListAsync();
        }

        // GET: api/Terapia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<terapia>> Getterapia(int id)
        {
          if (_context.terapia == null)
          {
              return NotFound();
          }
            var terapia = await _context.terapia.FindAsync(id);

            if (terapia == null)
            {
                return NotFound();
            }

            return terapia;
        }

        // PUT: api/Terapia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putterapia(int id, terapia terapia)
        {
            if (id != terapia.idTerapia)
            {
                return BadRequest();
            }

            _context.Entry(terapia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!terapiaExists(id))
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

        // POST: api/Terapia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<terapia>> Postterapia(terapia terapia)
        {
          if (_context.terapia == null)
          {
              return Problem("Entity set 'nancurunaisadbContext.terapia'  is null.");
          }
            _context.terapia.Add(terapia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getterapia", new { id = terapia.idTerapia }, terapia);
        }

        // DELETE: api/Terapia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteterapia(int id)
        {
            if (_context.terapia == null)
            {
                return NotFound();
            }
            var terapia = await _context.terapia.FindAsync(id);
            if (terapia == null)
            {
                return NotFound();
            }

            _context.terapia.Remove(terapia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool terapiaExists(int id)
        {
            return (_context.terapia?.Any(e => e.idTerapia == id)).GetValueOrDefault();
        }
    }
}
