namespace Mioni_Api.Models
{
    public class ImageUploadResult
    {
        public string FileName { get; set; } = null!;
        public required string ThumbnailUrl { get; set; }
        public required string MediumUrl { get; set; }
        public required string LargeUrl { get; set; }
    }
}
