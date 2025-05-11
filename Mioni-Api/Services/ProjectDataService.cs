using Microsoft.EntityFrameworkCore;
using Mioni_Api.Data;
using Mioni_Api.Domain.Entities;
using Mioni_Api.Services.Interfaces;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;

namespace Mioni_Api.Services
{
    public class ProjectDataService : IProjectDataService
    {
        private readonly AppDbContext _context;

        public ProjectDataService(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Project> GetAll () => _context.Projects;

        public async Task<Project?> GetByIdAsync(int id) =>
            await _context.Projects.FindAsync(id);

        public async Task<Project> CreateAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> DeleteAndReturnProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {id} not found");
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<Project> UpdateProjectAsync(int id, string? newTitle, string? newDescription, bool titleProvided, bool descriptionProvided)
        {
            var existingProject = await _context.Projects.FindAsync(id);

            if (existingProject == null)
            {
                throw new KeyNotFoundException($"Project with ID {id} not found");
            }

            bool changed = false;
            if (titleProvided)
            {
                existingProject.Title = newTitle;
                changed = true;
            }
            if (descriptionProvided)
            {
                existingProject.Description = newDescription;
                changed = true;
            }

            if (changed)
            {
                existingProject.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }

            return existingProject;
        }
    }
}
