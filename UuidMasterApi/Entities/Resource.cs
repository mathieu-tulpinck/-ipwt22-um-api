using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UuidMasterApi.Enums;

namespace UuidMasterApi.Entities
{
    public class Resource
    {
        [Key]
        public Guid Uuid { get; set; }
        [Required]// Adds a non-nullable constraint to the db schema.
        [Column(TypeName = "nvarchar(24)")]
        public Source Source { get; set; }
        [Required]
        [MaxLength(50)]
        public string EntityType { get; set; }// Enum?
        [Required]
        public int SourceEntityId { get; set; }
        [Required]
        public int EntityVersion { get; set; }

        public Resource(Source source, string entityType, int sourceEntityId, int entityVersion)
        {
            Uuid = Guid.NewGuid();
            Source = source;
            EntityType = entityType;
            SourceEntityId = sourceEntityId;
            EntityVersion = entityVersion;
        }

    }
}