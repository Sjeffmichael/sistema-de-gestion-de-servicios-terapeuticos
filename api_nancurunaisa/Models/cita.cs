﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_nancurunaisa.Models
{
    public partial class cita
    {
        public cita()
        {
            factura = new HashSet<factura>();
            pacienteCita = new HashSet<pacienteCita>();
            idMasajista = new HashSet<masajista>();
            idPromocion = new HashSet<promocion>();
            idTerapia = new HashSet<terapia>();
        }

        public int idCita { get; set; }
        public int? idHabitacion { get; set; }
        public DateTime fechaHora { get; set; }
        public bool? pendiente { get; set; }
        public string? direccion_domicilio { get; set; }
        public string? color { get; set; }

        [NotMapped]
        public string nombreSucursal { get; set; }

        [NotMapped]
        public string nombreHabitacion { get; set; }
        //[JsonIgnore]
        public virtual habitacion? idHabitacionNavigation { get; set; }
        public virtual ICollection<factura> factura { get; set; }
        public virtual ICollection<pacienteCita> pacienteCita { get; set; }

        public virtual ICollection<masajista> idMasajista { get; set; }
        public virtual ICollection<promocion> idPromocion { get; set; }
        public virtual ICollection<terapia> idTerapia { get; set; }
    }
}
