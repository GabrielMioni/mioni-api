using Mioni_Portfolio.Domain.Entities;
using Mioni_Portfolio.Models;

namespace Mioni_Portfolio.Factories
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
