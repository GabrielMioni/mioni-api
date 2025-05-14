namespace Mioni_Portfolio.GraphQL.Inputs
{
    public class RestoreProjectInput
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
