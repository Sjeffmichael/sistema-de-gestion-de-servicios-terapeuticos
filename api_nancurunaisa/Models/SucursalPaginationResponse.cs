namespace api_nancurunaisa.Models
{
    public class SucursalPaginationResponse
    {
        public List<sucursal> sucursales { get; set; } = new List<sucursal>();
        public int pages { get; set; }
        public int currentPage { get; set; }
    }
}
