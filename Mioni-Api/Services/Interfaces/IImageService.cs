using Mioni_Api.Models;

namespace Mioni_Api.Services.Interfaces
{
    public interface IImageService
    {
        Task<ImageUploadResult> UploadImageAsync(IFormFile file, string subfolder);
    }
}
