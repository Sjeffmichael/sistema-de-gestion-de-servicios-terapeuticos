using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class tipoAPNP
    {
        public int idTipoAPNP { get; set; }
        public int idAmnanesis { get; set; }
        public string nombreAPNP { get; set; } = null!;
        public string? tipo { get; set; }
        public string? cantidad { get; set; }
        public string? frecuencia { get; set; }

        public virtual APNP idAmnanesisNavigation { get; set; } = null!;
    }
}
