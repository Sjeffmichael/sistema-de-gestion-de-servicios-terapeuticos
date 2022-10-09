using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class VwPacientesCitasPendietes
    {
        public int idPaciente { get; set; }
        public string nombres { get; set; } = null!;
        public string apellidos { get; set; } = null!;
    }
}
