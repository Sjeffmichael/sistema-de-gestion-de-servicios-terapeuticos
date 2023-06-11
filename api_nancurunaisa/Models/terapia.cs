using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class terapia
    {
        public terapia()
        {
            idCita = new HashSet<cita>();
            idTerapeuta = new HashSet<terapeuta>();
        }

        public int? idTerapia { get; set; }
        public string nombreTerapia { get; set; } = null!;
        public int duracion { get; set; }
        public double precioDomicilio { get; set; }
        public double precioLocal { get; set; }
        public bool? activo { get; set; }

        public virtual ICollection<cita>? idCita { get; set; }
        public virtual ICollection<terapeuta>? idTerapeuta { get; set; }
    }
}
