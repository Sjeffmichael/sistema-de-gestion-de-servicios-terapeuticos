using Newtonsoft.Json;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_nancurunaisa.Models
{
    public partial class masajista
    {
        public masajista()
        {
            idCita = new HashSet<cita>();
            idDia = new HashSet<dia>();
        }

        public int? idMasajista { get; set; }
        public int? idSucursal { get; set; }
        //[UseSorting]
        public string nombres { get; set; } = null!;
        public string apellidos { get; set; } = null!;
        public DateTime fechaNacimiento { get; set; }
        public string correo { get; set; } = null!;
        public string password { get; set; } = null!;
        public string? foto { get; set; }
        public string roll { get; set; } = null!;
        public string numCel { get; set; } = null!;
        public bool? activo { get; set; }
        public string sexo { get; set; } = null!;
        public DateTime horaEntrada { get; set; }
        public DateTime horaSalida { get; set; }

        ////[NotMapped]
        ////public HotChocolate.Types.InterfaceType<Microsoft.AspNetCore.Http.HotChocolate.Types.InterfaceType<Microsoft.AspNetCore.Http.IFormFile>> fotoPerfil { get; set; }
        [JsonIgnore]
        public virtual sucursal? idSucursalNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<cita>? idCita { get; set; }
        public virtual ICollection<dia>? idDia { get; set; }
    }
}
