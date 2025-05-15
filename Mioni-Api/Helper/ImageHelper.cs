using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using HeyRed.Mime;
using Path = System.IO.Path;

namespace Mioni.Api.Helper
{
    public class ImageHelper
    {
        public static void DeleteImageIfExists(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public static string? GetExtensionFromMime(Stream stream)
        {
            if (stream.CanSeek)
                stream.Position = 0;

            var mime = MimeGuesser.GuessMimeType(stream);
            stream.Position = 0;

            return MimeGuesser.GuessExtension(mime);
        }

        public static bool IsValidImageMime(Stream stream, string[] allowedExtensions)
        {
            var ext = GetExtensionFromMime(stream);

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
