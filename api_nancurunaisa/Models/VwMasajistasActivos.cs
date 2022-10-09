using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class VwMasajistasActivos
    {
        public int idMasajista { get; set; }
        public int? idSucursal { get; set; }
        public string nombres { get; set; } = null!;
        public DateTime fechaNacimiento { get; set; }
        public string apellidos { get; set; } = null!;
        public string correo { get; set; } = null!;
        public string password { get; set; } = null!;
        public string? foto { get; set; }
        public string roll { get; set; } = null!;
        public string numCel { get; set; } = null!;
        public bool activo { get; set; }
        public string sexo { get; set; } = null!;
        public DateTime horaEntrada { get; set; }
        public DateTime horaSalida { get; set; }
    }
}
