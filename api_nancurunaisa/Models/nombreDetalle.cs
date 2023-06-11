using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class nombreDetalle
    {
        public nombreDetalle()
        {
            detalleHC = new HashSet<detalleHC>();
        }

        public int? idNombreDet { get; set; }
        public string nombreDetalle1 { get; set; } = null!;
        public bool? activo { get; set; }

        public virtual ICollection<detalleHC>? detalleHC { get; set; }
    }
}
