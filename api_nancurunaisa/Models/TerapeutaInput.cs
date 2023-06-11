namespace api_nancurunaisa.Models
{
    public class TerapeutaInput
    {
        public int? idTerapeuta { get; set; }
        public int idSucursal { get; set; }
        public DateTime horaEntrada { get; set; }
        public DateTime horaSalida { get; set; }
        public int idUsuario { get; set; }
        public List<diaLibre> diasLibres { get; set; }
        public List<int> terapias { get; set; }
    }
}
