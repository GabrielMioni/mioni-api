using Mioni_Api.GraphQL.Inputs;
using Mioni_Api.GraphQL.Payloads;
using Mioni_Api.Models;
using Mioni_Api.Services;

namespace Mioni_Api.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class ProjectMutations
    {
        public async Task<Project> AddProject(ProjectInput projectInput, [Service] ProjectService service)
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

        public async Task<UpdateProjectPayload> UpdateProject(UpdateProjectInput input, [Service] ProjectService service)
        {
            try
            {
                bool titleProvided = input.Title.HasValue;
                bool descriptionProvided = input.Description.HasValue;

                string? newTitle = input.Title.Value;
                string? newDescription = input.Description.Value;

                Project project = await service.UpdateProjectAsync(
                    input.Id,
                    newTitle,
                    newDescription,
                    titleProvided,
                    descriptionProvided);

                return new UpdateProjectPayload(project);
            }
            catch (System.Collections.Generic.KeyNotFoundException ex)
            {
                return new UpdateProjectPayload(null, new List<UserError> {
                    new UserError(ex.Message, "PROJECT_NOT_FOUND")
                });
            }
            catch (Exception ex)
            {
                return new UpdateProjectPayload(null, new List<UserError>{
                    new UserError("An unexpected error occurred while updating the project.", "UPDATE_FAILED")
                });
            }
        }
    }
}
