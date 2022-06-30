using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class VwCitasPendientesDomicilio
    {
        public int idCita { get; set; }
        public bool pendiente { get; set; }
        public int? idHabitacion { get; set; }
        public DateTime fechaHora { get; set; }
        public string? direccion_domicilio { get; set; }
        public string? color { get; set; }
    }
}
