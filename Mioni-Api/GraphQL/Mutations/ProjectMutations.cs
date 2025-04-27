using Mioni_Api.Domain.Entities;
using Mioni_Api.GraphQL.Inputs;
using Mioni_Api.GraphQL.Payloads;
using Mioni_Api.Services;
using Mioni_Api.Services.Interfaces;

namespace Mioni_Api.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class ProjectMutations
    {
        public async Task<AddProjectPayload> AddProject(ProjectInput projectInput, [Service] IProjectService service)
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
            catch (Exception ex)
            {
                return new AddProjectPayload(null, new List<UserError>
                {
                    new UserError("An unexpected error occurred while adding the project.", "ADD_FAILED")
                });
            }
        }

        public async Task<DeleteProjectPayload> DeleteProject(int id, [Service] IProjectService service)
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
            catch (Exception ex)
            {
                return new DeleteProjectPayload(null, new List<UserError>{
                    new UserError("An unexpected error occurred while deleting the project.", "DELETE_FAILED")
                });
            }
        }

        public async Task<RestoreProjectPayload> RestoreProject(RestoreProjectInput input, [Service] IProjectService service)
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
            catch (Exception ex)
            {
                return new RestoreProjectPayload(null, new List<UserError>
                {
                    new UserError("An unexpected error occurred while restoring the project.", "RESTORE_FAILED")
                });
            }
        }

        public async Task<UpdateProjectPayload> UpdateProject(UpdateProjectInput input, [Service] IProjectService service)
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
