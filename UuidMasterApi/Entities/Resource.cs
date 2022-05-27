using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UuidMasterApi.Enums;

namespace UuidMasterApi.Entities
{
    public class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(36)]
        public string Uuid { get; set; } // Not Guid because not unique per row in db.
        [Required]// Adds a non-nullable constraint to the db schema.
        [Column(TypeName = "nvarchar(24)")]
        public Source Source { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(24)")]
        public EntityType EntityType { get; set; }
        [Required]
        [MaxLength(254)] // Max chars in email (RFC).
        public string SourceEntityId { get; set; }
        [Required]
        public int EntityVersion { get; set; }

        public Resource(Source source, string uuid, EntityType entityType, string sourceEntityId, int entityVersion)
        {
            Uuid = uuid;
            Source = source;
            EntityType = entityType;
            SourceEntityId = sourceEntityId;
            EntityVersion = entityVersion;
        }

        public Resource(Source source, EntityType entityType, string sourceEntityId, int entityVersion)
        {
            Uuid = Guid.NewGuid().ToString();
            Source = source;
            EntityType = entityType;
            SourceEntityId = sourceEntityId;
            EntityVersion = entityVersion;
        }



        // Used by UuidMasterApiDbContext
        public Resource(int id, string uuid, Source source, EntityType entityType, string sourceEntityId, int entityVersion)
        {
            Id = id;
            Uuid = uuid;
            Source = source;
            EntityType = entityType;
            SourceEntityId = sourceEntityId;
            EntityVersion = entityVersion;
        }

    }
}