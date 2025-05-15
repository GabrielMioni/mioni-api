using Mioni.Api.Domain.Entities;
using Mioni.Api.Models;

namespace Mioni.Api.Factories
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
