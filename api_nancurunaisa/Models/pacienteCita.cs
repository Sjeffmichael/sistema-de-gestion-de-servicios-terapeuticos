using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class pacienteCita
    {
        public int idCita { get; set; }
        public int idPaciente { get; set; }

        public virtual cita idCitaNavigation { get; set; } = null!;
        public virtual paciente idPacienteNavigation { get; set; } = null!;
        public virtual amnanesisInfo amnanesisInfo { get; set; } = null!;
    }
}
