namespace Mioni.Api.Services.Interfaces
{
    public interface IImageStorageService
    {
        Task<bool> DeleteImageAsync(int projectId);
        Task<string> UploadImageAsync(IFormFile file, string subfolder);
    }
}
