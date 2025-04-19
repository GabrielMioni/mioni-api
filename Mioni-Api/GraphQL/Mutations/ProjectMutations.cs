using Mioni_Api.GraphQL.Inputs;
using Mioni_Api.Models;
using Mioni_Api.Services;

namespace Mioni_Api.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class ProjectMutations
    {
        public async Task<Project> AddProject([Service] ProjectService service, ProjectInput projectInput)
        {
            if (projectInput == null)
            {
                throw new ArgumentNullException(nameof(projectInput));
            }

            var newProject = new Project
            {
                Title = projectInput.Title,
                Description = projectInput.Description,
                CreatedAt = DateTime.UtcNow,
            };

            Project savedProject = await service.CreateAsync(newProject);
            
            return newProject;
        }
    }
}
