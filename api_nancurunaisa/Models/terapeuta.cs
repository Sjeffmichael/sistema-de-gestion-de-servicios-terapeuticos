using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class terapeuta
    {
        public terapeuta()
        {
            diaLibre = new HashSet<diaLibre>();
            idCita = new HashSet<cita>();
            idTerapia = new HashSet<terapia>();
        }

        public int? idTerapeuta { get; set; }
        public int idSucursal { get; set; }
        public DateTime horaEntrada { get; set; }
        public DateTime horaSalida { get; set; }
        public int idUsuario { get; set; }

        public virtual sucursal? idSucursalNavigation { get; set; } = null!;
        public virtual usuario? idUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<diaLibre> diaLibre { get; set; }

        public virtual ICollection<cita>? idCita { get; set; }
        public virtual ICollection<terapia>? idTerapia { get; set; }
    }
}
