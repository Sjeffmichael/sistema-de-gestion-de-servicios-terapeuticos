using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class sucursal
    {
        public sucursal()
        {
            habitacion = new HashSet<habitacion>();
            masajista = new HashSet<masajista>();
        }

        public int idSucursal { get; set; }
        public string nombreSucursal { get; set; } = null!;
        public string direccion { get; set; } = null!;

        public virtual ICollection<habitacion> habitacion { get; set; }
        public virtual ICollection<masajista> masajista { get; set; }
    }
}
