using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class habitacion
    {
        public habitacion()
        {
            cita = new HashSet<cita>();
        }

        public int idHabitacion { get; set; }
        public int idSucursal { get; set; }
        public string nombreHabitacion { get; set; } = null!;

        public virtual sucursal idSucursalNavigation { get; set; } = null!;
        public virtual ICollection<cita> cita { get; set; }
    }
}
