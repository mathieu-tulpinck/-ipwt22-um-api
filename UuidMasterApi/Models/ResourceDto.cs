using System.ComponentModel;
using UuidMasterApi.Enums;

namespace UuidMasterApi.Models
{
    // At present, no difference between Resource and ResourceDto.
    public class ResourceDto
    {
        [TypeConverter(typeof(GuidConverter))]
        public Guid Uuid { get; set; }
        public Source Source { get; set; }
        public EntityType EntityType { get; set; }
        public string SourceEntityId { get; set; } = string.Empty;
        public int EntityVersion { get; set; }
    }
}