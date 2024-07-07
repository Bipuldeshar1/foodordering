
namespace foodBackend.utility.image
{
    public class ImageService : IImage
    {
        private readonly IWebHostEnvironment env;

        public ImageService(IWebHostEnvironment env)
        {
            this.env = env;
        }
        public async Task<string> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty or null.");
            }
            var uploadFolder = Path.Combine(env.ContentRootPath, "assets", "uploads");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(uploadFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Path.Combine("assets", "uploads", fileName).Replace("\\", "/");
        }

        public async Task<string> GetImageAsync(string imageUrl)
        {
            var imagePath = Path.Combine(env.ContentRootPath, imageUrl.TrimStart('/'));
            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException("Image not found.");
            }

            byte[] imageBytes;
            using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    imageBytes = reader.ReadBytes((int)stream.Length);
                }
            }

            return Convert.ToBase64String(imageBytes);
        }


    }
}
