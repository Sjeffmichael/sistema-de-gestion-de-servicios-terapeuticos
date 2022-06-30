namespace api_nancurunaisa.Models
{
    public class FacturaPaginationResponse
    {
        public List<factura> facturas { get; set; } = new List<factura>();
        public int pages { get; set; }
        public int currentPage { get; set; }
    }
}
