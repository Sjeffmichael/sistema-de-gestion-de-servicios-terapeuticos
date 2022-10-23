using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class detalleHC
    {
        public int idDetalle { get; set; }
        public int idNombreDet { get; set; }
        public int idPaciente { get; set; }
        public int? idCita { get; set; }
        public string? descripcion { get; set; }

        public virtual cita? idCitaNavigation { get; set; }
        public virtual nombreDetalle idNombreDetNavigation { get; set; } = null!;
        public virtual paciente idPacienteNavigation { get; set; } = null!;
    }
}
