using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace api_nancurunaisa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformeController : ControllerBase
    {
        private readonly nancurunaisadbContext _context;

        public InformeController(nancurunaisadbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<IEnumerable<SucursalInforme>> Getcita(string date, int type)
        //{
        //    var citas = new List<cita>();
        //    if (type == 0)
        //    {
        //        //Getting the number of week of the year from date
        //        DayOfWeek firstDay = DayOfWeek.Sunday;
        //        CalendarWeekRule rule = CalendarWeekRule.FirstDay;
        //        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
        //        Calendar cal = dfi.Calendar;
        //        var my_date = cal.GetWeekOfYear(DateTime.Parse(date), rule, firstDay);

        //        //Getting all appointments in the week and year from the given date
        //        citas = _context.cita
        //                      .Include(h => h.idHabitacionNavigation)
        //                      .ThenInclude(s => s.idSucursalNavigation)
        //                      .Include(f => f.factura).ToList()
        //                      .Where(c => cal.GetWeekOfYear(c.fechaHora, rule, firstDay) == my_date)
        //                      .Where(c => c.fechaHora.Year == DateTime.Parse(date).Year)
        //                      .Where(d => d.idHabitacionNavigation != null).ToList();
        //    }
        //    else
        //    {
        //        //Getting all appointments in the month and year from the given date
        //        citas = _context.cita
        //                      .Include(x => x.idHabitacionNavigation)
        //                      .ThenInclude(s => s.idSucursalNavigation)
        //                      .Include(x => x.factura).ToList()
        //                      .Where(c => c.fechaHora.Month == DateTime.Parse(date).Month)
        //                      .Where(c => c.fechaHora.Year == DateTime.Parse(date).Year)
        //                      .Where(d => d.idHabitacionNavigation != null).ToList();
        //    }

            //var citas2 = (from c in citas
            //              group c by c.idHabitacionNavigation.idSucursal into nc
            //              select new SucursalInforme
            //              {
            //                  idSucursal = nc.Key,
            //                  nombreSucursal = nc.ToList()
            //                  .Select(c => c.idHabitacionNavigation.idSucursalNavigation.nombreSucursal)
            //                  .First(),
            //                  citas = nc.ToList(),
            //                  totalCitas = nc.ToList().Count,
            //                  totalGanancias = (float)nc.ToList().Sum(c => c.factura.Sum(f => f.total)),
            //              });
            
            //return citas2;

        //}

        //[HttpGet]
        //public async Task<IEnumerable<cita>> GetMasajista(int id, string date)
        //{
        //    var dateTime_date = DateTime.Parse(date);
        //    var first_day_month = new DateTime(dateTime_date.Year, dateTime_date.Month, 1);
        //    var last_day_month = first_day_month.AddMonths(1).AddDays(-1);
        //    var citas = new List<cita>();

        //    if (dateTime_date.Day <= 15)
        //    {
        //        citas = await _context.cita
        //           .Include(m => m.idMasajista.Where(m => m.idMasajista == id))
        //           .Where(
        //               c => c.fechaHora.Month == dateTime_date.Month &&
        //               c.fechaHora.Year == dateTime_date.Year &&
        //               dateTime_date.Day >= first_day_month.Day &&
        //               dateTime_date.Day <= 15
        //           ).ToListAsync();
        //    }
        //    else
        //    {
        //        citas = await _context.cita
        //            .Include(m => m.idMasajista.Where(m => m.idMasajista == id))
        //            .Where(
        //                c => c.fechaHora.Month == dateTime_date.Month &&
        //                c.fechaHora.Year == dateTime_date.Year &&
        //                dateTime_date.Day <= last_day_month.Day &&
        //                dateTime_date.Day > 15
        //            ).ToListAsync();
        //    }

        //    return citas;
        //}

    }
}
