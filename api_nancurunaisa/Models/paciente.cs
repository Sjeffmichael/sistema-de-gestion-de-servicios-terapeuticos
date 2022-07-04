using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class paciente
    {
        public paciente()
        {
            amnanesis = new HashSet<amnanesis>();
            pacienteCita = new HashSet<pacienteCita>();
        }

        public int idPaciente { get; set; }
        public string nombres { get; set; } = null!;
        public string apellidos { get; set; } = null!;
        public string sexo { get; set; } = null!;
        public int edad { get; set; }
        public string nacionalidad { get; set; } = null!;
        public string? profesion_oficio { get; set; }
        public double? horas_trabajo { get; set; }
        public string numCel { get; set; } = null!;
        public DateTime fecha_nacimiento { get; set; }

        public virtual ICollection<amnanesis> amnanesis { get; set; }

        [JsonIgnore]
        public virtual ICollection<pacienteCita> pacienteCita { get; set; }
    }
}
