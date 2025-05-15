namespace Mioni.Api.Services.Interfaces
{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(IFormFile file, string subfolder);
    }
}
