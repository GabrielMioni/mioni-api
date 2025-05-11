namespace Mioni_Api.Models
{
    public class ProjectImageDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string FileName { get; set; } = default!;
        public string Subfolder { get; set; } = default!;
        public int SortOrder { get; set; } = 0;
        public string? AltText { get; set; }
        public string? Caption { get; set; }

        public string ThumbnailUrl { get; set; } = default!;
        public string MediumUrl { get; set; } = default!;
        public required string LargeUrl { get; set; }
    }
}
