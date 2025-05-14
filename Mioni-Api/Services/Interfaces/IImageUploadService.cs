namespace Mioni_Portfolio.Services.Interfaces
{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(IFormFile file, string subfolder);
    }
}
