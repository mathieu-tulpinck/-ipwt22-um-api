using UuidMasterApi.Enums;

namespace UuidMasterApi.Models
{
    // At present, no difference between Resource and ResourceDto.
    public class ResourceDto
    {
        public Guid Uuid { get; set; }
        public string Source { get; set; } = string.Empty;
        public string EntityType { get; set; } = string.Empty;
        public string SourceEntityId { get; set; } = string.Empty;
        public int EntityVersion { get; set; }
    }
}