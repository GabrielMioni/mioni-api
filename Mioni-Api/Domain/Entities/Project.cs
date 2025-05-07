namespace Mioni_Api.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<ProjectImage>? ProjectImages { get; set; } = new();
    }
}
