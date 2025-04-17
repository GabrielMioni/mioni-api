using Mioni_Api.Data;
using Mioni_Api.Models;

namespace Mioni_Api.Services
{
    public class ProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Project> GetAll () => _context.Projects;

        public async Task<Project?> GetByIdAsync(int id) =>
            await _context.Projects.FindAsync(id);

        public async Task<Project> CreateAsync(Project project)
        {
            project.CreatedAt = DateTime.UtcNow;
            project.UpdatedAt = DateTime.UtcNow;
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project?> UpdateAsync(int id, Project updatedProject)
        {
            var project = await GetByIdAsync(id);
            if (project == null)
                return null;

            project.Title = updatedProject.Title;
            project.Description = updatedProject.Description;
            project.UpdatedAt = DateTime.UtcNow;
            _context.Projects.Update(project);

            await _context.SaveChangesAsync();
            return project;
        }
    }
}
