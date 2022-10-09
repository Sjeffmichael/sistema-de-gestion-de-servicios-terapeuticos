using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class amnanesis
    {
        public amnanesis()
        {
            APP = new HashSet<APP>();
        }

        public int idAmnanesis { get; set; }
        public int idPaciente { get; set; }
        public string? escolaridad { get; set; }
        public string? estadoCivil { get; set; }
        public string? direccion { get; set; }

        [JsonIgnore]
        public virtual paciente idPacienteNavigation { get; set; } = null!;
        public virtual AFP AFP { get; set; } = null!;
        public virtual APNP APNP { get; set; } = null!;
        public virtual ICollection<APP> APP { get; set; }
    }
}
