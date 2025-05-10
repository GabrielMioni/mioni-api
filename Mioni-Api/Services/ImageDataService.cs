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

        public Task<ProjectImage> UpdateImageAsync(int id, string? newTitle, string? newDescription, bool titleProvided, bool descriptionProvided)
        {
            throw new NotImplementedException();
        }
    }
}
