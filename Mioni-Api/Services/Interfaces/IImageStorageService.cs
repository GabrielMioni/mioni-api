namespace Mioni.Api.Services.Interfaces
{
    public interface IImageStorageService
    {
        Task<string> UploadImageAsync(IFormFile file, string subfolder);
    }
}
