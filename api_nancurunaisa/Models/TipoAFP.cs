using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class TipoAFP
    {
        public int idTipoAFP { get; set; }
        public int idAmnanesis { get; set; }
        public string nombreAFP { get; set; } = null!;
        public string? descripcion { get; set; }

        public virtual AFP idAmnanesisNavigation { get; set; } = null!;
    }
}
