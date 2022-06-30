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
    public class PromocionController : ControllerBase
    {
        private readonly nancurunaisadbContext _context;

        public PromocionController(nancurunaisadbContext context)
        {
            _context = context;
        }

        // GET: api/Promocion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<promocion>>> Getpromocion(int Page, int PerPage, string? nombrePromocion="")
        {
          if (_context.promocion == null)
          {
              return NotFound();
          }
            var pageResult = (float)PerPage;
            var pageCount = Math.Ceiling(_context.promocion.Where(t => t.nombrePromocion.Contains(nombrePromocion)).Count() / (float)PerPage);

            var promocionesResults = await _context.promocion.Where(t => t.nombrePromocion.Contains(nombrePromocion))
                  .Skip((Page - 1) * PerPage)
                  .Take((int)pageResult)
                  .ToListAsync();

            var response = new PromocionPaginationResponse
            {
                promociones = promocionesResults,
                currentPage = Page,
                pages = (int)pageCount
            };

            return Ok(response);
        }

        // GET: api/Promocion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<promocion>> Getpromocion(int id)
        {
          if (_context.promocion == null)
          {
              return NotFound();
          }
            var promocion = await _context.promocion.FindAsync(id);

            if (promocion == null)
            {
                return NotFound();
            }

            return promocion;
        }

        // PUT: api/Promocion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpromocion(int id, promocion promocion)
        {
            if (id != promocion.idPromocion)
            {
                return BadRequest();
            }

            _context.Entry(promocion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!promocionExists(id))
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

        // POST: api/Promocion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<promocion>> Postpromocion(promocion promocion)
        {
          if (_context.promocion == null)
          {
              return Problem("Entity set 'nancurunaisadbContext.promocion'  is null.");
          }
            _context.promocion.Add(promocion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpromocion", new { id = promocion.idPromocion }, promocion);
        }

        // DELETE: api/Promocion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepromocion(int id)
        {
            if (_context.promocion == null)
            {
                return NotFound();
            }
            var promocion = await _context.promocion.FindAsync(id);
            if (promocion == null)
            {
                return NotFound();
            }

            _context.promocion.Remove(promocion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool promocionExists(int id)
        {
            return (_context.promocion?.Any(e => e.idPromocion == id)).GetValueOrDefault();
        }
    }
}
