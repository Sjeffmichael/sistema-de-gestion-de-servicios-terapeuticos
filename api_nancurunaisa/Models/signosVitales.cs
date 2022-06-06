using System;
using System.Collections.Generic;

namespace api_nancurunaisa.Models
{
    public partial class signosVitales
    {
        public int idCita { get; set; }
        public int idPaciente { get; set; }
        public int FC { get; set; }
        public int FR { get; set; }
        public int PA { get; set; }
        public double T { get; set; }

        public virtual amnanesisInfo id { get; set; } = null!;
    }
}
