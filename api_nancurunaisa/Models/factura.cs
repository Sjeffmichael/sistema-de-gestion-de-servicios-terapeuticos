using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class factura
    {
        public int? idFactura { get; set; }
        public int idCita { get; set; }
        public double? descuento { get; set; }
        public double subTotal { get; set; }
        public double total { get; set; }
        public bool? activo { get; set; }

        public virtual cita? idCitaNavigation { get; set; } = null!;
    }
}
