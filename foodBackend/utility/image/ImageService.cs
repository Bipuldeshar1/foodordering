
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace foodBackend.utility.image
{
    public class ImageService : IImage
    {
        private readonly IWebHostEnvironment env;
        private readonly Cloudinary _cloudinary;

        public ImageService(IWebHostEnvironment env,IOptions<CloudinarySettings>config)
        {
            this.env = env;
            var acc = new Account(
      config.Value.CloudName,
      config.Value.ApiKey,
      config.Value.ApiSecret);

            _cloudinary = new Cloudinary(acc);
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


        public async Task<ImageUploadResult> UploadToCloudinary(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                await using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File= new FileDescription(file.FileName,stream),
                    Transformation = new Transformation().Crop("fill").Gravity("face").Width(500).Height(500)
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
                
            }
            return uploadResult;
        }


    }
}
