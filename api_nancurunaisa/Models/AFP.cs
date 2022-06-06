using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class AFP
    {
        public AFP()
        {
            TipoAFP = new HashSet<TipoAFP>();
        }

        public int idAmnanesis { get; set; }
        public string? otros { get; set; }

        public virtual amnanesis idAmnanesisNavigation { get; set; } = null!;
        public virtual ICollection<TipoAFP> TipoAFP { get; set; }
    }
}
