﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Mioni.Api.Domain.Entities
{
    public class ProjectImage
    {
        public int Id { get; set; }

        public string FileName { get; private set; } = null!;
        public string? AltText { get; private set; }
        public string? Caption { get; private set; }

        public int ProjectId { get; private set; }
        public Project Project { get; private set; } = default!;

        public int SortOrder { get; private set; } = 0;

        private ProjectImage() { }

        public static ProjectImage Create(
            string fileName,
            int projectId,
            string? altText = null,
            string? caption = null,
            int sortOrder = 0)
        {
            return new ProjectImage
            {
                FileName = fileName,
                AltText = altText,
                Caption = caption,
                ProjectId = projectId,
                SortOrder = sortOrder
            };
        }

        public void UpdateAltText(string? altText)
        {
            AltText = altText?.Trim();
        }
        public void UpdateCaption(string? caption)
        {
            Caption = caption?.Trim();
        }
        public void RenameFile(string newFileName)
        {
            if (string.IsNullOrWhiteSpace(newFileName))
                throw new ArgumentException("New file name is required.", nameof(newFileName));
            FileName = newFileName;
        }


        [NotMapped]
        public string LargeUrl => $"/uploads/projects/{ProjectId}/{Id}/large/{FileName}";

        [NotMapped]
        public string MediumUrl => $"/uploads/projects/{ProjectId}/{Id}/medium/{FileName}";

        [NotMapped]
        public string ThumbnailUrl => $"/uploads/projects/{ProjectId}/{Id}/thumb/{FileName}";
    }
}
