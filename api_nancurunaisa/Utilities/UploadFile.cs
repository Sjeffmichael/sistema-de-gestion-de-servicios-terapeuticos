namespace api_nancurunaisa.Utilities
{
    public class UploadFile
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        UploadFile(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        //public async Task<string> SaveImage(IFormFile fotoPerfil)
        //{
        //    string nombreFoto = new String(System.IO.System.IO.Path.GetFileNameWithoutExtension(fotoPerfil.Name).Take(10).ToArray()).Replace(' ', '-');
        //    nombreFoto = nombreFoto + DateTime.Now.ToString("yymmssfff") + System.IO.System.IO.Path.GetExtension(fotoPerfil.FileName);
        //    var rutaFoto = System.IO.System.IO.Path.Combine(_hostEnvironment.ContentRootPath, "Images", nombreFoto);

        //    using (var fileStream = new FileStream(rutaFoto, FileMode.Create))
        //    {
        //        await fotoPerfil.CopyToAsync(fileStream);
        //    }

        //    return nombreFoto;
        //}
    }
}
