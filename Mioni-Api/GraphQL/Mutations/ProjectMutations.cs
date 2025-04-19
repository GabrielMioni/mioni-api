using Microsoft.EntityFrameworkCore;
using Mioni_Api.GraphQL.Inputs;
using Mioni_Api.Models;
using Mioni_Api.Services;

namespace Mioni_Api.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class ProjectMutations
    {
        private readonly ProjectService _projectService;

        public ProjectMutations(ProjectService service) {
            _projectService = service;
        }

        public async Task<Project> AddProject(ProjectInput projectInput)
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

            Project savedProject = await _projectService.CreateAsync(newProject);
            
            return newProject;
        }

        //public async Task<Project> UpdateProject([Service] ProjectService service, ProjectInput projectInput)
        //{

        //}
    }
}
