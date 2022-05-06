using System.ComponentModel.DataAnnotations;
using UuidMasterApi.Enums;

namespace UuidMasterApi.Entities
{
    public class Resource
    {
        [Key]
        public Guid Uuid { get; set; }
        [Required]// Adds a non-nullable constraint to the db schema. 
        public SourceType Source { get; set; }
        [Required]
        public ulong SourceEntityId { get; set; }// (unsigned) Int 64 corresponds to bigint in mysql
        [Required]
        [MaxLength(50)]
        public string EntityType { get; set; }// Enum?
        [Required]
        public ulong EntityVersion { get; set; }

        public Resource(SourceType source, ulong sourceEntityId, string entityType, ulong entityVersion)
        {
            Uuid = Guid.NewGuid();
            Source = source;
            SourceEntityId = sourceEntityId;
            EntityType = entityType;
            EntityVersion = entityVersion;
        }

    }
}