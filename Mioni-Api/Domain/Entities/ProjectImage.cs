using System.ComponentModel.DataAnnotations.Schema;

namespace Mioni_Api.Domain.Entities
{
    public class ProjectImage
    {
        public int Id { get; set; }

        public string FileName { get; private set; } = null!;
        public string Subfolder { get; private set; } = null!;

        public string? AltText { get; private set; }
        public string? Caption { get; private set; }

        public int ProjectId { get; private set; }
        public Project Project { get; private set; } = default!;

        private ProjectImage() { }

        public static ProjectImage Create(
            string fileName,
            string subfolder,
            int projectId,
            string? altText = null,
            string? caption = null)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name is required.", nameof(fileName));
            
            if (string.IsNullOrWhiteSpace(subfolder))
                throw new ArgumentException("Subfolder is required.", nameof(subfolder));

            return new ProjectImage
            {
                FileName = fileName,
                Subfolder = subfolder,
                AltText = altText,
                Caption = caption,
                ProjectId = projectId
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
        public string Thumnailurl => $"/uploads/{Subfolder}/thumb/{FileName}";

        [NotMapped]
        public string MediumUrl => $"/uploads/{Subfolder}/medium/{FileName}";

        [NotMapped]
        public string LargeUrl => $"/uploads/{Subfolder}/large/{FileName}";
    }
}
