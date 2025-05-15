using Microsoft.EntityFrameworkCore;
using Mioni.Api.Data;
using Mioni.Api.Domain.Entities;
using Mioni.Api.Services.Interfaces;

namespace Mioni.Api.Services
{
    public class ImageDataService : IImageDataService
    {
        private readonly AppDbContext _context;

        public ImageDataService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectImage> CreateAsync(ProjectImage projectImage)
        {
            _context.ProjectImages.Add(projectImage);
            await _context.SaveChangesAsync();
            return projectImage;
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

        public async Task<int> GetMaxSortOrderByProjectId(int id) =>
            await _context.ProjectImages
                .Where(i => i.ProjectId == id)
                .MaxAsync(i => (int?)i.SortOrder) ?? -1;

        public Task<ProjectImage> UpdateImageAsync(int id, string? newTitle, string? newDescription, bool titleProvided, bool descriptionProvided)
        {
            throw new NotImplementedException();
        }
    }
}
