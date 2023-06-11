using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class rol
    {
        public rol()
        {
            idOperacion = new HashSet<operacion>();
            idUsuario = new HashSet<usuario>();
        }

        public int? idRol { get; set; }
        public string nombreRol { get; set; } = null!;
        public string descripcion { get; set; }
        public bool? activo { get; set; }

        public virtual ICollection<operacion>? idOperacion { get; set; }
        public virtual ICollection<usuario>? idUsuario { get; set; }
    }
}
