using Microsoft.AspNetCore.Mvc;
using Mioni_Api.Domain.Entities;
using Mioni_Api.Factories;
using Mioni_Api.Services.Interfaces;

namespace Mioni_Api.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageUploadService _imageUploadService;
        private readonly IImageDataService _imageDataService;

        public ImagesController(IImageUploadService imageUploadService, IImageDataService imageDataService)
        {
            _imageUploadService = imageUploadService;
            _imageDataService = imageDataService;
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
                var fileName = await _imageUploadService.UploadImageAsync(file, subfolder);

                if (fileName == null)
                    return BadRequest("Image upload failed.");

                var entity = ProjectImage.Create(
                    fileName,
                    subfolder,
                    projectId,
                    altText,
                    caption,
                    await _imageDataService.GetMaxSortOrderByProjectId(projectId) + 1
                );
                await _imageDataService.CreateAsync(entity);

                var dto = ProjectImageDtoFactory.Create(entity);

                return CreatedAtAction(nameof(GetImageById), new { id = entity.Id }, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var image = await _imageDataService.GetByIdAsync(id);
            if (image == null)
                return NotFound();
            var dto = ProjectImageDtoFactory.Create(image);
            return Ok(dto);
        }
    }
}
