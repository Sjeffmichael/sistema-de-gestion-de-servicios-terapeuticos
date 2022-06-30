namespace api_nancurunaisa.Models
{
    public class TerapiaPaginationResponse
    {
        public List<terapia> terapias { get; set; } = new List<terapia>();
        public int pages { get; set; }
        public int currentPage { get; set; }
    }
}
