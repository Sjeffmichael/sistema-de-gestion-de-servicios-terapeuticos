namespace api_nancurunaisa.Models
{
    public class HabitacionPaginationResponse
    {
        public List<habitacion> habitaciones { get; set; } = new List<habitacion>();
        public int pages { get; set; }
        public int currentPage { get; set; }
    }
}
