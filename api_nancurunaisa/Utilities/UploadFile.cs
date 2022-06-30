namespace api_nancurunaisa.Utilities
{
    public class UploadFile
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        UploadFile(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public async Task<string> SaveImage(IFormFile fotoPerfil)
        {
            string nombreFoto = new String(Path.GetFileNameWithoutExtension(fotoPerfil.Name).Take(10).ToArray()).Replace(' ', '-');
            nombreFoto = nombreFoto + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(fotoPerfil.FileName);
            var rutaFoto = Path.Combine(_hostEnvironment.ContentRootPath, "Images", nombreFoto);

            using (var fileStream = new FileStream(rutaFoto, FileMode.Create))
            {
                await fotoPerfil.CopyToAsync(fileStream);
            }

            return nombreFoto;
        }
    }
}
