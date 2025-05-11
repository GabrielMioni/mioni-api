using Mioni_Api.Domain.Entities;
using Mioni_Api.Models;

namespace Mioni_Api.Factories
{
    public class ProjectImageDtoFactory
    {
        public static ProjectImageDto Create(ProjectImage entity)
        {
            return new ProjectImageDto
            {
                Id = entity.Id,
                ProjectId = entity.ProjectId,
                FileName = entity.FileName,
                Subfolder = entity.Subfolder,
                SortOrder = entity.SortOrder,
                AltText = entity.AltText,
                Caption = entity.Caption,
                ThumbnailUrl = entity.ThumbnailUrl,
                MediumUrl = entity.MediumUrl,
                LargeUrl = entity.LargeUrl
            };
        }
    }
}
