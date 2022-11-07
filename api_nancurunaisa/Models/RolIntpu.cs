namespace api_nancurunaisa.Models
{
    public class RolIntpu
    {
        public int? idRol { get; set; }
        public string nombreRol { get; set; } = null!;
        public string descripcion { get; set; }
        public bool? activo { get; set; }

        public List<int> operaciones { get; set; }
    }
}
