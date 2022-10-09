namespace api_nancurunaisa.Models
{
    public class PromocionPaginationResponse
    {
        public List<promocion> promociones { get; set; } = new List<promocion>();
        public int pages { get; set; }
        public int currentPage { get; set; }
    }
}
