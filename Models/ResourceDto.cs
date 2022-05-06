using UuidMasterApi.Enums;

namespace UuidMasterApi.Models
{
    public class ResourceDto
    {
        public Guid Uuid { get; set; }
        public SourceType Source { get; set; }
        public ulong SourceEntityId { get; set; }
        public string EntityType { get; set; } = string.Empty;
        public ulong EntityVersion { get; set; }
    }
}