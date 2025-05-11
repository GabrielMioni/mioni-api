using Microsoft.AspNetCore.Mvc;
using Mioni_Api.Domain.Entities;
using Mioni_Api.Services.Interfaces;

namespace Mioni_Api.Controllers.API
{
    public class ImagesController : Controller
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
                var result = await _imageUploadService.UploadImageAsync(file, subfolder);

                if (result == null)
                    return BadRequest("Image upload failed.");

                var entity = ProjectImage.Create(
                    result.FileName,
                    subfolder,
                    projectId,
                    altText,
                    caption,
                    await _imageDataService.GetMaxSortOrderByProjectId(projectId) + 1
                );
                await _imageDataService.CreateAsync(entity);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
