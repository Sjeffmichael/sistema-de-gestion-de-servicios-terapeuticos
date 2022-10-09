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
    public class SucursalController : ControllerBase
    {
        private readonly nancurunaisadbContext _context;

        public SucursalController(nancurunaisadbContext context)
        {
            _context = context;
        }

        // GET: api/Sucursal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<sucursal>>> Getsucursal(int Page, int PerPage, string? nombreSucursal="")
        {
          if (_context.sucursal == null)
          {
              return NotFound();
          }
            var pageResult = (float)PerPage;
            var pageCount = Math.Ceiling(_context.sucursal.Where(t => t.nombreSucursal.Contains(nombreSucursal)).Count() / (float)PerPage);

            var sucursalesResults = await _context.sucursal.Where(t => t.nombreSucursal.Contains(nombreSucursal))
                  .Skip((Page - 1) * PerPage)
                  .Take((int)pageResult)
                  .ToListAsync();

            var response = new SucursalPaginationResponse
            {
                sucursales = sucursalesResults,
                currentPage = Page,
                pages = (int)pageCount
            };
            return Ok(response);
        }

        // GET: api/Sucursal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<sucursal>> Getsucursal(int id)
        {
          if (_context.sucursal == null)
          {
              return NotFound();
          }
            var sucursal = await _context.sucursal.Include(h => h.habitacion).FirstOrDefaultAsync(s => s.idSucursal == id);

            if (sucursal == null)
            {
                return NotFound();
            }

            return sucursal;
        }

        // PUT: api/Sucursal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putsucursal(int id, sucursal sucursal)
        {
            if (id != sucursal.idSucursal)
            {
                return BadRequest();
            }

            _context.Entry(sucursal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sucursalExists(id))
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

        // POST: api/Sucursal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<sucursal>> Postsucursal(sucursal sucursal)
        {
          if (_context.sucursal == null)
          {
              return Problem("Entity set 'nancurunaisadbContext.sucursal'  is null.");
          }
            _context.sucursal.Add(sucursal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getsucursal", new { id = sucursal.idSucursal }, sucursal);
        }

        // DELETE: api/Sucursal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletesucursal(int id)
        {
            if (_context.sucursal == null)
            {
                return NotFound();
            }
            var sucursal = await _context.sucursal.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            _context.sucursal.Remove(sucursal);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool sucursalExists(int id)
        {
            return (_context.sucursal?.Any(e => e.idSucursal == id)).GetValueOrDefault();
        }
    }
}
