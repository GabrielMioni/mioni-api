using Mioni.Api.Domain.Entities;

namespace Mioni.Api.Services.Interfaces
{
    public interface IProjectDataService
    {
        IQueryable<Project> GetAll();
        Task<Project?> GetByIdAsync(int id);
        Task<Project> CreateAsync(Project project);
        Task<Project> DeleteAndReturnProjectAsync(int id);
        Task<Project> UpdateProjectAsync(
            int id,
            string? newTitle,
            string? newDescription,
            bool titleProvided,
            bool descriptionProvided);
    }
}
