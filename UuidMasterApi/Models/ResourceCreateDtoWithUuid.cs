using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UuidMasterApi.Enums;

namespace UuidMasterApi.Models
{
    public class ResourceCreateDtoWithUuid
    {
        [Required(ErrorMessage = "uuid field is required.")]
        [TypeConverter(typeof(GuidConverter))]
        public Guid Uuid { get; set; }
        [Required(ErrorMessage = "source field is required.")]
        public Source Source { get; set; }
        [Required(ErrorMessage = "entityType field is required.")]
        public EntityType EntityType { get; set; }
        [Required(ErrorMessage = "sourceEntityId field is required.")]
        [MaxLength(254)]
        public string SourceEntityId { get; set; } = String.Empty;
        [Required(ErrorMessage = "entityVersion field is required.")]
        public int EntityVersion { get; set; }
    }
}