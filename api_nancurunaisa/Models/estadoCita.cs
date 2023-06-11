using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class estadoCita
    {
        public estadoCita()
        {
            cita = new HashSet<cita>();
        }

        public int? idEstado { get; set; }
        public string nombre { get; set; } = null!;

        public virtual ICollection<cita>? cita { get; set; }
    }
}
