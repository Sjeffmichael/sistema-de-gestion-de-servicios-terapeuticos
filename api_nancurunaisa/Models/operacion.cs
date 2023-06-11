using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class operacion
    {
        public operacion()
        {
            idRol = new HashSet<rol>();
        }

        public int? idOperacion { get; set; }
        public int idModulo { get; set; }
        public string nombre { get; set; } = null!;
        public string descripcion { get; set; } = null!;
        public bool? activo { get; set; }

        public virtual modulo? idModuloNavigation { get; set; } = null!;

        public virtual ICollection<rol>? idRol { get; set; }
    }
}
