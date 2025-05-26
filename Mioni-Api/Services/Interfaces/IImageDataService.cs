using Mioni.Api.Domain.Entities;

namespace Mioni.Api.Services.Interfaces
{
    public interface IImageDataService
    {
        IQueryable<ProjectImage> GetAll();
        Task<ProjectImage?> GetByIdAsync(int id);
        Task<int> GetMaxSortOrderByProjectId(int id);
        Task<ProjectImage> CreateAsync(ProjectImage projectImage);
        Task<ProjectImage> DeleteAndReturnImageAsync(int id);
        Task<ProjectImage> UpdateImageAsync(
            int id,
            string? newFileName,
            string? newAltText,
            string? newCaption,
            bool fileNameProvided = false,
            bool altTextProvided = false,
            bool captionProvided = false);
    }
}
