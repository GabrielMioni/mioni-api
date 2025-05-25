using Microsoft.Extensions.Options;
using Mioni.Api.Helper;
using Mioni.Api.Models;
using Mioni.Api.Services.Interfaces;
using Mioni.Api.Settings;
using Path = System.IO.Path;

namespace Mioni.Api.Services
{
    public class ImageStorageService : IImageStorageService
    {
        private readonly ImageSettings _settings;

        public ImageStorageService(IOptions<ImageSettings> settings) {
            _settings = settings.Value;
        }

        public async Task<bool> DeleteImageAsync(int projectId)
        {
            var subfolder = $"projects/{projectId}";
            var wwwRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var baseDir = Path.Combine(wwwRoot, _settings.UploadRoot, subfolder);

            return await Task.Run(() =>
            {
                if (Directory.Exists(baseDir))
                {
                    Directory.Delete(baseDir, true);
                    return true;
                }
                return false;
            });          
        }

        public async Task<string> UploadImageAsync(IFormFile file, string subfolder)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentNullException(nameof(file));

            if (file.Length > _settings.MaxFileSizeBytes)
                throw new ArgumentException(
                    $"File must be smaller than {_settings.MaxFileSizeBytes} bytes"
                );

            using var stream = file.OpenReadStream();

            if (!ImageHelper.IsValidImage(stream, out var fileExtension))
                throw new ArgumentException(
                    $"Unable to determine file extension from uploaded content. Allowed types: {string.Join(", ", _settings.AllowedExtensions)}"
                );

            if (!_settings.AllowedExtensions
                .Any(x => x.Equals(fileExtension, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException(
                    $"File extension {fileExtension} is not allowed. Allowed types: {string.Join(", ", _settings.AllowedExtensions)}"
                );

            var fileName = $"{Guid.NewGuid()}{fileExtension}";

            var wwwRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var baseDir = Path.Combine(wwwRoot, _settings.UploadRoot, subfolder);

            var thumbPath = Path.Combine(baseDir, "thumb", fileName);
            var mediumPath = Path.Combine(baseDir, "medium", fileName);
            var largePath = Path.Combine(baseDir, "large", fileName);

            stream.Position = 0;
            await ImageHelper.ResizeAndSaveAsync(stream, thumbPath, _settings.ThumbnailWidth, _settings.ThumbnailHeight);

            stream.Position = 0;
            await ImageHelper.ResizeAndSaveAsync(stream, mediumPath, _settings.MediumWidth, _settings.MediumHeight);

            stream.Position = 0;
            await ImageHelper.ResizeAndSaveAsync(stream, largePath, _settings.MaxWidth, _settings.MaxHeight);

            return fileName;
        }
    }
}
