using System.ComponentModel.DataAnnotations;

namespace UuidMasterApi.Models
{
    public class ResourceCreateDto
    {
        [Required(ErrorMessage = "source field is required.")]
        [MaxLength(8)]
        public string Source { get; set; } = string.Empty;
        [Required(ErrorMessage = "entityType field is required.")]
        [MaxLength(50)]
        public string EntityType { get; set; } = string.Empty;
        [Required(ErrorMessage = "sourceEntityId field is required.")]
        public int SourceEntityId { get; set; }
        [Required(ErrorMessage = "entityVersion field is required.")]
        public int EntityVersion { get; set; }
    }
}