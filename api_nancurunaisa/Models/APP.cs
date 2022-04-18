using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class APP
    {
        public int idAPP { get; set; }
        public int idAmnanesis { get; set; }
        public string nombre { get; set; } = null!;
        public string? descripcion { get; set; }

        public virtual amnanesis idAmnanesisNavigation { get; set; } = null!;
    }
}
