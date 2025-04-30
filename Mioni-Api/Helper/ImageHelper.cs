using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using HeyRed.Mime;
using Path = System.IO.Path;

namespace Mioni_Api.Helper
{
    public class ImageHelper
    {
        public static bool IsValidImageMime(Stream stream, string[] allowedExtensions)
        {
            if (stream.CanSeek)
                stream.Position = 0;

            var mime = MimeGuesser.GuessMimeType(stream);
            stream.Position = 0;

            if (string.IsNullOrEmpty(mime))
                return false;

            var ext = MimeGuesser.GuessExtension(mime);

            return ext != null && allowedExtensions.Contains(ext.ToLowerInvariant());
        }

        public static async Task ResizeAndSaveAsync (
            Stream inputStream,
            string outputPath,
            int maxWidth,
            int maxHeight,
            int quality = 75)
        {
            if (inputStream.CanSeek)
                inputStream.Position = 0;

            using var image = await Image.LoadAsync(inputStream);

            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(maxWidth, maxHeight),
                Mode = ResizeMode.Max
            }));

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);

            await image.SaveAsJpegAsync(outputPath, new JpegEncoder
            {
                Quality = quality
            });
        }
    }
}
