namespace api_nancurunaisa.Models
{
    public class CitaDto
    {
        //public int idCita { get; set; }
        public int? idHabitacion { get; set; }
        public DateTime fechaHora { get; set; }
        //public bool? pendiente { get; set; }
        public string? direccion_domicilio { get; set; }
        public string? color { get; set; }

        public List<int> idMasajista { get; set; }
        public List<int> idTerapia { get; set; }
        public List<int> idPromocion { get; set; }
    }
}
