using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class amnanesisInfo
    {
        public int idCita { get; set; }
        public int idPaciente { get; set; }
        public string? motivo { get; set; }
        public string? HEA { get; set; }
        public string? observacionAnalisis { get; set; }
        public string? diagnosticoProblema { get; set; }
        public DateTime? proxCita { get; set; }

        public virtual pacienteCita id { get; set; }
        public virtual signosVitales signosVitales { get; set; }
    }
}
