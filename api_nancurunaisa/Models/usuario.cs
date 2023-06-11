using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class usuario
    {
        public usuario()
        {
            terapeuta = new HashSet<terapeuta>();
            idRol = new HashSet<rol>();
        }

        public int? idUsuario { get; set; }
        public string email { get; set; } = null!;
        public string? password { get; set; } = null!;
        public string nombres { get; set; } = null!;
        public string apellidos { get; set; } = null!;
        public DateTime fechaNacimiento { get; set; }
        public string? foto { get; set; }
        public string numCel { get; set; } = null!;
        public string sexo { get; set; } = null!;
        public bool? activo { get; set; }

        public virtual ICollection<terapeuta>? terapeuta { get; set; }

        public virtual ICollection<rol>? idRol { get; set; }
    }
}
