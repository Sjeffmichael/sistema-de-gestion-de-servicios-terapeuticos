using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class diaLibre
    {
        public int idTerapeuta { get; set; }
        public int idDia { get; set; }

        public virtual terapeuta idTerapeutaNavigation { get; set; } = null!;
    }
}
