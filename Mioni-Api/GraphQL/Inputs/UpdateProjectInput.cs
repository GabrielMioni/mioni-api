using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace Mioni_Portfolio.GraphQL.Inputs
{
    public class UpdateProjectInput
    {
        public int Id { get; set; }
        public Optional<string?> Title { get; set; }
        public Optional<string?> Description { get; set; }
    }
}
