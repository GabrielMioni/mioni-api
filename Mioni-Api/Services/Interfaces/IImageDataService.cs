using Mioni_Api.Domain.Entities;

namespace Mioni_Api.Services.Interfaces
{
    public interface IImageDataService
    {
        IQueryable<ProjectImage> GetAll();
        Task<ProjectImage?> GetByIdAsync(int id);
        Task<ProjectImage> CreateAsync(ProjectImage projectImage);
        Task<ProjectImage> DeleteAndReturnImageAsync(int id);
        Task<ProjectImage> UpdateImageAsync(
            int id,
            string? newTitle,
            string? newDescription,
            bool titleProvided,
            bool descriptionProvided);
    }
}
