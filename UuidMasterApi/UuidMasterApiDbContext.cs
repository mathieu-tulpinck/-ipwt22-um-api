using Microsoft.EntityFrameworkCore;
using UuidMasterApi.Entities;
using UuidMasterApi.Enums;

namespace UuidMasterApi
{
    public class UuidMasterApiDbContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; } = null!;

        public UuidMasterApiDbContext(DbContextOptions<UuidMasterApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var uuid = Guid.NewGuid();
            modelBuilder.Entity<Resource>()
                .HasData(
                    new Resource(1, uuid.ToString(), Source.FRONTEND, EntityType.SESSION, "78", 1),
                    new Resource(2, uuid.ToString(), Source.CRM, EntityType.SESSION, "13", 1)
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
