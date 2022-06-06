using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class cita
    {
        public cita()
        {
            factura = new HashSet<factura>();
            pacienteCita = new HashSet<pacienteCita>();
            idMasajista = new HashSet<masajista>();
            idPromocion = new HashSet<promocion>();
            idTerapia = new HashSet<terapia>();
        }

        public int idCita { get; set; }
        public int idHabitacion { get; set; }
        public DateTime fechaHora { get; set; }
        public bool? pendiente { get; set; }
        public string? direccion_domicilio { get; set; }

        public virtual habitacion idHabitacionNavigation { get; set; } = null!;
        public virtual ICollection<factura> factura { get; set; }
        public virtual ICollection<pacienteCita> pacienteCita { get; set; }

        public virtual ICollection<masajista> idMasajista { get; set; }
        public virtual ICollection<promocion> idPromocion { get; set; }
        public virtual ICollection<terapia> idTerapia { get; set; }
    }
}
