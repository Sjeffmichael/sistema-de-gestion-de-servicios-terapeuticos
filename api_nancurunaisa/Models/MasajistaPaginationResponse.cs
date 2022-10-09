namespace api_nancurunaisa.Models
{
    public class MasajistaPaginationResponse
    {
        public List<masajista> masajistas { get; set; } = new List<masajista>();
        public int pages { get; set; }
        public int currentPage { get; set; }

    }
}
