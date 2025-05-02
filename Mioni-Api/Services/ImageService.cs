using Microsoft.Extensions.Options;
using Mioni_Api.Helper;
using Mioni_Api.Models;
using Mioni_Api.Services.Interfaces;
using Mioni_Api.Settings;
using Path = System.IO.Path;

namespace Mioni_Api.Services
{
    public class ImageService : IImageService
    {
        private readonly ImageSettings _settings;

        public ImageService(IOptions<ImageSettings> settings) {
            _settings = settings.Value;
        }

        public async Task<ImageUploadResult> UploadImageAsync(IFormFile file, string subfolder)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentNullException(nameof(file));

            if (file.Length > _settings.MaxFileSizeBytes)
                throw new ArgumentException($"File must be smaller than {_settings.MaxFileSizeBytes} bytes");

            using var stream = file.OpenReadStream();

            if (!ImageHelper.IsValidImageMime(stream, _settings.AllowedExtensions))
                throw new ArgumentException($"File type not allowed. Allowed types: {string.Join(", ", _settings.AllowedExtensions)}");

            var fileExtension = ImageHelper.GetExtensionFromMime(stream)
                ?? throw new ArgumentException("Unable to determine file extension from upload content.");

            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var baseDir = Path.Combine(Directory.GetCurrentDirectory(), _settings.UploadRoot, subfolder);

            var thumbPath = Path.Combine(baseDir, "thumb", fileName);
            var mediumPath = Path.Combine(baseDir, "medium", fileName);
            var largePath = Path.Combine(baseDir, "large", fileName);

            stream.Position = 0;
            await ImageHelper.ResizeAndSaveAsync(stream, thumbPath, _settings.ThumbnailWidth, _settings.ThumbnailHeight);

            stream.Position = 0;
            await ImageHelper.ResizeAndSaveAsync(stream, mediumPath, _settings.MediumWidth, _settings.MediumHeight);

            stream.Position = 0;
            await ImageHelper.ResizeAndSaveAsync(stream, largePath, _settings.MaxWidth, _settings.MaxHeight);

            var publicBase = $"/uploads/{subfolder}".TrimEnd('/');

            return new ImageUploadResult
            {
                ThumbnailUrl = $"{publicBase}/thumb/{fileName}",
                MediumUrl = $"{publicBase}/medium/{fileName}",
                LargeUrl = $"{publicBase}/large/{fileName}",

            };
        }
    }
}
