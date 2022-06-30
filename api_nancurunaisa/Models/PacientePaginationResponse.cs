namespace api_nancurunaisa.Models
{
    public class PacientePaginationResponse
    {
        public List<paciente> pacientes { get; set; } = new List<paciente>();
        public int pages { get; set; }
        public int currentPage { get; set; }
    }
}
