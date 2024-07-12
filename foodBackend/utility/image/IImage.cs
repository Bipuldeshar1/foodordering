using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.utility.image
{
    public interface IImage
    {
        Task<string>UploadImageAsync(IFormFile file);
         Task<string> GetImageAsync(string imageUrl);

        Task<ImageUploadResult> UploadToCloudinary( IFormFile file);
    }
}
