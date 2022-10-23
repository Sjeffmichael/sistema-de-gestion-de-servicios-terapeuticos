namespace api_nancurunaisa.Models
{
    public class MasajistaCredentials
    {
        public string? email { get; set; }
        public string? password { get; set; }
    }

    public class Token
    {
        public AuthToken token { get; set; }
    }
}
