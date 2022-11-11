namespace api_nancurunaisa.Models
{
    public class UsuarioInput
    {
        public int? idUsuario { get; set; }
        public string email { get; set; } = null!;
        public string nombres { get; set; } = null!;
        public string apellidos { get; set; } = null!;
        public DateTime fechaNacimiento { get; set; }
        public string? password { get; set; }
        public string numCel { get; set; } = null!;
        public string sexo { get; set; } = null!;
        public bool? activo { get; set; }
        public List<int> roles { get; set; } = null!;
    }
}
