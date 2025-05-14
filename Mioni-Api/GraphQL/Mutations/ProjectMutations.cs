using Mioni_Portfolio.Domain.Entities;
using Mioni_Portfolio.GraphQL.Inputs;
using Mioni_Portfolio.GraphQL.Payloads;
using Mioni_Portfolio.Services;
using Mioni_Portfolio.Services.Interfaces;

namespace Mioni_Portfolio.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class ProjectMutations
    {
        public async Task<AddProjectPayload> AddProject(ProjectInput projectInput, [Service] IProjectDataService service)
        {
            try
            {
                var newProject = new Project
                {
                    Title = projectInput.Title,
                    Description = projectInput.Description,
                    CreatedAt = DateTime.UtcNow,
                };

                Project addedProject = await service.CreateAsync(newProject);

                return new AddProjectPayload(addedProject);
            }
            catch (Exception)
            {
                return new AddProjectPayload(null, new List<UserError>
                {
                    new UserError("An unexpected error occurred while adding the project.", "ADD_FAILED")
                });
            }
        }

        public async Task<DeleteProjectPayload> DeleteProject(int id, [Service] IProjectDataService service)
        {
            try
            {
                Project deletedProject = await service.DeleteAndReturnProjectAsync(id);
                return new DeleteProjectPayload(deletedProject);
            }
            catch (System.Collections.Generic.KeyNotFoundException ex)
            {
                return new DeleteProjectPayload(null, new List<UserError> {
                    new UserError(ex.Message, "PROJECT_NOT_FOUND")
                });
            }
            catch (Exception)
            {
                return new DeleteProjectPayload(null, new List<UserError>{
                    new UserError("An unexpected error occurred while deleting the project.", "DELETE_FAILED")
                });
            }
        }

        public async Task<RestoreProjectPayload> RestoreProject(RestoreProjectInput input, [Service] IProjectDataService service)
        {
            try
            {
                var restoredProject = new Project
                {
                    Title = input.Title,
                    Description = input.Description,
                    CreatedAt = input.CreatedAt,
                    UpdatedAt = input.UpdatedAt
                };
                Project addedProject = await service.CreateAsync(restoredProject);
                return new RestoreProjectPayload(addedProject);
            }
            catch (Exception)
            {
                return new RestoreProjectPayload(null, new List<UserError>
                {
                    new UserError("An unexpected error occurred while restoring the project.", "RESTORE_FAILED")
                });
            }
        }

        public async Task<UpdateProjectPayload> UpdateProject(UpdateProjectInput input, [Service] IProjectDataService service)
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
            catch (Exception)
            {
                return new UpdateProjectPayload(null, new List<UserError>{
                    new UserError("An unexpected error occurred while updating the project.", "UPDATE_FAILED")
                });
            }
        }
    }
}
