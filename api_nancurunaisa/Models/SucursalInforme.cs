namespace api_nancurunaisa.Models
{
    public class SucursalInforme
    {
        public int idSucursal { get; set; }
        public string nombreSucursal { get; set; }
        public List<cita> citas { get; set; }
        public int totalCitas { get; set; }
        public float totalGanancias { get; set; }
    }
}
