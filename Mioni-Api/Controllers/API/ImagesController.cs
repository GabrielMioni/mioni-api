using Microsoft.AspNetCore.Mvc;
using Mioni_Api.Data;
using Mioni_Api.Domain.Entities;
using Mioni_Api.Services.Interfaces;

namespace Mioni_Api.Controllers.API
{
    public class ImagesController : Controller
    {
        private readonly IImageUploadService _imageService;
        private readonly IProjectService _projectService;
        private readonly AppDbContext _context;

        public ImagesController(IImageUploadService imageService, IProjectService projectService, AppDbContext context)
        {
            _imageService = imageService;
            _projectService = projectService;
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(
            IFormFile file,
            int projectId,
            string? altText = null,
            string? caption = null)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");
            try
            {
                var subfolder = $"projects/{projectId}";
                var result = await _imageService.UploadImageAsync(file, subfolder);

                if (result == null)
                    return BadRequest("Image upload failed.");

                var entity = ProjectImage.Create(
                    result.FileName,
                    subfolder,
                    projectId,
                    altText,
                    caption,
                    await _projectService.GetMaxSortOrderByProjectId(projectId) + 1
                );
                await _context.SaveChangesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
