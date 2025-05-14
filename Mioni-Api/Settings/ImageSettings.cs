namespace Mioni_Portfolio.Settings
{
    public class ImageSettings
    {
        public string[] AllowedExtensions { get; set; } = new[] { ".jpg", ".jpeg", ".png" };

        public int MaxHeight { get; set; } = 1600;
        public long MaxFileSizeBytes { get; set; } = 5 * 1024 * 1024; // 5 MB
        public int MaxWidth { get; set; } = 1600;

        public int MediumHeight { get; set; } = 800;
        public int MediumWidth { get; set; } = 800;

        public int Quality { get; set; } = 75;

        public int ThumbnailHeight { get; set; } = 150;
        public int ThumbnailWidth { get; set; } = 150;

        public string UploadRoot { get; set; } = "uploads/";
    }
}