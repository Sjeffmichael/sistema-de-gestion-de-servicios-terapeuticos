namespace api_nancurunaisa.Models
{
    public class CitaInput
    {
        public int? idCita { get; set; }
        public DateTime fechaHora { get; set; }
        public string? direccionDomicilio { get; set; }
        public int? idHabitacion { get; set; } = null!;
        public int? idEstado { get; set; } = 3;
        public TimeSpan? horaInicio { get; set; }
        public TimeSpan? horaFin { get; set; }
        public List<int>? idPacientes { get; set; }
        public List<int>? idPromociones { get; set; }
        public List<int>? idTerapeutas { get; set; }
        public List<int>? idTerapias { get; set; }
    }
}
