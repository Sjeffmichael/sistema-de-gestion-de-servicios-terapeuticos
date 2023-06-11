using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class cita
    {
        public cita()
        {
            detalleHC = new HashSet<detalleHC>();
            factura = new HashSet<factura>();
            idPaciente = new HashSet<paciente>();
            idPromocion = new HashSet<promocion>();
            idTerapeuta = new HashSet<terapeuta>();
            idTerapia = new HashSet<terapia>();
        }

        public int? idCita { get; set; }
        public DateTime fechaHora { get; set; }
        public string? direccionDomicilio { get; set; }
        public int? idHabitacion { get; set; }
        public int idEstado { get; set; } = 3;
        public DateTime? horaInicio { get; set; }
        public DateTime? horaFin { get; set; }

        public virtual estadoCita? idEstadoNavigation { get; set; } = null!;
        public virtual habitacion? idHabitacionNavigation { get; set; } = null!;
        public virtual ICollection<detalleHC>? detalleHC { get; set; }
        public virtual ICollection<factura>? factura { get; set; }

        public virtual ICollection<paciente>? idPaciente { get; set; }
        public virtual ICollection<promocion>? idPromocion { get; set; }
        public virtual ICollection<terapeuta>? idTerapeuta { get; set; }
        public virtual ICollection<terapia>? idTerapia { get; set; }
    }
}
