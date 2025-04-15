using Mioni_Api.GraphQL.Inputs;
using Mioni_Api.Models;

namespace Mioni_Api.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class ProjectMutations
    {
        private static List<Project> _projects = new List<Project>()
        {
            new Project
            {
                Id = 1,
                Title = "Project 1",
                Description = "Description of Project 1",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Project
            {
                Id = 2,
                Title = "Project 2",
                Description = "Description of Project 2",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        public Project AddProject(ProjectInput input)
        {
            var newProject = new Project
            {
                Id = _projects.Max(p => p.Id) + 1,
                Title = input.Title,
                Description = input.Description,
                CreatedAt = DateTime.UtcNow,
            };
            _projects.Add(newProject);
            return newProject;
        }
    }
}
