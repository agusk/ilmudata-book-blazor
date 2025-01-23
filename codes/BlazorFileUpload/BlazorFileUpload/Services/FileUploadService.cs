using Microsoft.AspNetCore.Components.Forms;


namespace BlazorFileUpload.Services
{
    public class FileUploadService
    {
        private readonly IWebHostEnvironment _environment;

        public FileUploadService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string UploadPath => Path.Combine(_environment.WebRootPath, "uploads");

        public async Task<string> SaveFileAsync(IBrowserFile file)
        {
            if (!Directory.Exists(UploadPath))
            {
                Directory.CreateDirectory(UploadPath);
            }

            var fileName = $"{Guid.NewGuid()}_{file.Name}";
            var filePath = Path.Combine(UploadPath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.OpenReadStream().CopyToAsync(fileStream);
            }

            return $"/uploads/{fileName}";
        }
    }
}
