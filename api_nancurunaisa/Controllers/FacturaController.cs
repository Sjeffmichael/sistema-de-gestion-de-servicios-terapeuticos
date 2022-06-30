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
    public class FacturaController : ControllerBase
    {
        private readonly nancurunaisadbContext _context;

        public FacturaController(nancurunaisadbContext context)
        {
            _context = context;
        }

        // GET: api/Factura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<factura>>> Getfactura()
        {
          if (_context.factura == null)
          {
              return NotFound();
          }
            return await _context.factura.ToListAsync();
        }

        // GET: api/Factura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<factura>> Getfactura(int id)
        {
          if (_context.factura == null)
          {
              return NotFound();
          }
            var factura = await _context.factura.FindAsync(id);

            if (factura == null)
            {
                return NotFound();
            }

            return factura;
        }

        // PUT: api/Factura/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfactura(int id, factura factura)
        {
            if (id != factura.idFactura)
            {
                return BadRequest();
            }

            _context.Entry(factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!facturaExists(id))
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

        // POST: api/Factura
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<factura>> Postfactura(factura factura)
        {
          if (_context.factura == null)
          {
              return Problem("Entity set 'nancurunaisadbContext.factura'  is null.");
          }
            _context.factura.Add(factura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfactura", new { id = factura.idFactura }, factura);
        }

        // DELETE: api/Factura/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletefactura(int id)
        {
            if (_context.factura == null)
            {
                return NotFound();
            }
            var factura = await _context.factura.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _context.factura.Remove(factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool facturaExists(int id)
        {
            return (_context.factura?.Any(e => e.idFactura == id)).GetValueOrDefault();
        }
    }
}
