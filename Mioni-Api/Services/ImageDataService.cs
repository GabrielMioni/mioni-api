using Mioni_Api.Domain.Entities;
using Mioni_Api.Services.Interfaces;

namespace Mioni_Api.Services
{
    public class ImageDataService : IImageDataService
    {
        public Task<ProjectImage> CreateAsync(ProjectImage projectImage)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectImage> DeleteAndReturnImageAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProjectImage> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectImage?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectImage> UpdateImageAsync(int id, string? newTitle, string? newDescription, bool titleProvided, bool descriptionProvided)
        {
            throw new NotImplementedException();
        }
    }
}
