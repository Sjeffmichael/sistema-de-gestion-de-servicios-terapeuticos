using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class paciente
    {
        public paciente()
        {
            detalleHC = new HashSet<detalleHC>();
            idCita = new HashSet<cita>();
        }

        public int idPaciente { get; set; }
        public string nombres { get; set; } = null!;
        public string apellidos { get; set; } = null!;
        public string sexo { get; set; } = null!;
        public string nacionalidad { get; set; } = null!;
        public string? profesionOficio { get; set; }
        public double? horasTrabajo { get; set; }
        public string numCel { get; set; } = null!;
        public DateTime fechaNacimiento { get; set; }
        public string? escolaridad { get; set; }
        public string? estadoCivil { get; set; }
        public string? direccion { get; set; }
        public bool? activo { get; set; }

        public virtual ICollection<detalleHC> detalleHC { get; set; }

        public virtual ICollection<cita> idCita { get; set; }
    }
}
