using Mioni_Api.Models;

namespace Mioni_Api.Services.Interfaces
{
    public interface IImageUploadService
    {
        Task<ImageUploadResult> UploadImageAsync(IFormFile file, string subfolder);
    }
}
