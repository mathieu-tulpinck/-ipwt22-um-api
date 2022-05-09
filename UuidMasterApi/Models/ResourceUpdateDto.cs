using System.ComponentModel.DataAnnotations;

namespace UuidMasterApi.Models
{
    public class ResourceUpdateDto
    {
        [Required(ErrorMessage = "uuid field is required.")]
        public Guid Uuid { get; set; }
        [Required(ErrorMessage = "entityVersion field is required.")]
        public int EntityVersion { get; set; }
    }
}