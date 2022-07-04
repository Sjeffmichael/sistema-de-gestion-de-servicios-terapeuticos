using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_nancurunaisa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasajistaInformeController : ControllerBase
    {
        private readonly nancurunaisadbContext _context;
        public MasajistaInformeController(nancurunaisadbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<cita>> GetMasajista(int id, string date)
        {
            var dateTime_date = DateTime.Parse(date);
            var first_day_month = new DateTime(dateTime_date.Year, dateTime_date.Month, 1);
            var day_15 = new DateTime(dateTime_date.Year, dateTime_date.Month, 15);
            var last_day_month = first_day_month.AddMonths(1).AddDays(-1);
            var citas = new List<cita>();

            if (dateTime_date.Day <= day_15.Day)
            {
                citas = await _context.cita
                   .Include(m => m.idMasajista.Where(m => m.idMasajista == id))
                   .Where(
                       c => c.fechaHora.Month == dateTime_date.Month &&
                       c.idMasajista.Any(m => m.idMasajista == id) &&
                       c.fechaHora.Year == dateTime_date.Year &&
                       c.fechaHora.Day >= first_day_month.Day &&
                       c.fechaHora.Day <= day_15.Day
                   ).ToListAsync();

            }
            else
            {
                citas = await _context.cita
                    .Include(m => m.idMasajista.Where(m => m.idMasajista == id))
                    .Where(
                        c => c.fechaHora.Month == dateTime_date.Month &&
                        c.idMasajista.Any(m => m.idMasajista == id) &&
                        c.fechaHora.Year == dateTime_date.Year &&
                        c.fechaHora.Day <= last_day_month.Day &&
                        c.fechaHora.Day > day_15.Day
                    ).ToListAsync();
            }

            return citas;
        }
    }
}
