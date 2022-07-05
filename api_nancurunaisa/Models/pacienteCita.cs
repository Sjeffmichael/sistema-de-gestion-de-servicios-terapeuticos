using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace api_nancurunaisa.Models
{
    
    public partial class pacienteCita
    {
        public int idCita { get; set; }
        public int idPaciente { get; set; }
        [JsonIgnore]
        public virtual cita? idCitaNavigation { get; set; }
        public virtual paciente? idPacienteNavigation { get; set; }

        public virtual amnanesisInfo? amnanesisInfo { get; set; }
    }
}
