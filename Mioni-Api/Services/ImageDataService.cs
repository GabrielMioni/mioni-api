using Microsoft.EntityFrameworkCore;
using Mioni.Api.Data;
using Mioni.Api.Domain.Entities;
using Mioni.Api.Services.Interfaces;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;

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

        public async Task<ProjectImage> DeleteAndReturnImageAsync(int id)
        {
            var projectImage = await _context.ProjectImages.FindAsync(id);

            if (projectImage == null)
            {
                throw new KeyNotFoundException($"ProjectImage with ID {id} not found");
            }

            _context.ProjectImages.Remove(projectImage);
            await _context.SaveChangesAsync();

            return projectImage;
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
            var sortOrders = await _context.ProjectImages
                .Where(i => i.ProjectId == id)
                .Select(i => i.SortOrder)
                .ToListAsync();

            return sortOrders.Any() ? sortOrders.Max() : -1;
        }

        public Task<ProjectImage> UpdateImageAsync(int id, string? newTitle, string? newDescription, bool titleProvided, bool descriptionProvided)
        {
            throw new NotImplementedException();
        }
    }
}
