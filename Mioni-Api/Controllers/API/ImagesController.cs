using Microsoft.AspNetCore.Mvc;
using Mioni.Api.Domain.Entities;
using Mioni.Api.Factories;
using Mioni.Api.Services.Interfaces;

namespace Mioni.Api.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageStorageService _imageUploadService;
        private readonly IImageDataService _imageDataService;

        public ImagesController(IImageStorageService imageUploadService, IImageDataService imageDataService)
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
                var entity = ProjectImage.Create(
                    fileName: "",
                    projectId,
                    altText,
                    caption,
                    await _imageDataService.GetMaxSortOrderByProjectId(projectId) + 1
                );
                await _imageDataService.CreateAsync(entity);

                var subfolder = $"projects/{projectId}/{entity.Id}";
                var fileName = await _imageUploadService.UploadImageAsync(file, subfolder);

                if (fileName == null)
                    return BadRequest("Image upload failed.");

                var projectImage = await _imageDataService
                    .UpdateImageAsync(entity.Id, fileName, null, null, true);

                var dto = ProjectImageDtoFactory.Create(projectImage);

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
