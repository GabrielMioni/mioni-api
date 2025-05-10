using Microsoft.EntityFrameworkCore;
using Mioni_Api.Data;
using Mioni_Api.Domain.Entities;
using Mioni_Api.Services.Interfaces;

namespace Mioni_Api.Services
{
    public class ImageDataService : IImageDataService
    {
        private readonly AppDbContext _context;

        public ImageDataService(AppDbContext context)
        {
            _context = context;
        }

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

        public async Task<int> GetMaxSortOrderByProjectId(int id)
        {
            return await _context.ProjectImages
                .Where(i => i.ProjectId == id)
                .MaxAsync(i => (int?)i.SortOrder) ?? -1;
        }

        public Task<ProjectImage> UpdateImageAsync(int id, string? newTitle, string? newDescription, bool titleProvided, bool descriptionProvided)
        {
            throw new NotImplementedException();
        }
    }
}
