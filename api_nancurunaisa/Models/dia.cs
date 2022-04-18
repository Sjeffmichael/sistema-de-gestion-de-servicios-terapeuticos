using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class dia
    {
        public dia()
        {
            idMasajista = new HashSet<masajista>();
        }

        public int idDia { get; set; }
        public string nombreDia { get; set; } = null!;

        public virtual ICollection<masajista> idMasajista { get; set; }
    }
}
