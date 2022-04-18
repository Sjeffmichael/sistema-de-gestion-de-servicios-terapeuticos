using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class promocion
    {
        public promocion()
        {
            idCita = new HashSet<cita>();
        }

        public int idPromocion { get; set; }
        public string nombrePromocion { get; set; } = null!;
        public string descripcion { get; set; } = null!;
        public bool? activo { get; set; }

        public virtual ICollection<cita> idCita { get; set; }
    }
}
