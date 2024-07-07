namespace foodBackend.utility.image
{
    public interface IImage
    {
        Task<string>UploadImageAsync(IFormFile file);
        public Task<string> GetImageAsync(string imageUrl);
    }
}
