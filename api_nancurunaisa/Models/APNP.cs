using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class APNP
    {
        public APNP()
        {
            tipoAPNP = new HashSet<tipoAPNP>();
        }

        public int idAmnanesis { get; set; }
        public bool farmacos { get; set; }
        public string? nombPosFar { get; set; }
        public int? horasSueno { get; set; }

        public virtual amnanesis idAmnanesisNavigation { get; set; } = null!;
        public virtual ICollection<tipoAPNP> tipoAPNP { get; set; }
    }
}
