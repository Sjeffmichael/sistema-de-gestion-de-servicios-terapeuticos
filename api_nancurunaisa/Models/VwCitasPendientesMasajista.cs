using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class VwCitasPendientesMasajista
    {
        public int idMasajista { get; set; }
        public string nombres { get; set; } = null!;
        public string apellidos { get; set; } = null!;
        public int? Citas_Pendientes { get; set; }
    }
}
