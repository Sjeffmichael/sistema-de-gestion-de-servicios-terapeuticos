using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class modulo
    {
        public modulo()
        {
            operacion = new HashSet<operacion>();
        }

        public int idModulo { get; set; }
        public string nombre { get; set; } = null!;
        public bool? activo { get; set; }

        public virtual ICollection<operacion> operacion { get; set; }
    }
}
