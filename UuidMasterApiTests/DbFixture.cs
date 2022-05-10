using Microsoft.EntityFrameworkCore;
using UuidMasterApi;
using Xunit;

namespace UuidMasterApi.Tests
{

    public class DbFixture : IDisposable
    {
        private readonly  UuidMasterApiDbContext _dbContext;
        public readonly string databaseName = "uuidmasterapi_tests";
        public readonly string ConnectionString;
        
        private bool _disposed;

        public DbFixture()
        {
            ConnectionString = $"Server=localhost,1433;Database={databaseName};User=sa;Password=Student1";

            var builder = new DbContextOptionsBuilder<UuidMasterApiDbContext>();

            builder.UseSqlServer(ConnectionString);
            _dbContext = new UuidMasterApiDbContext(builder.Options);

            // _dbContext.Database.Migrate();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // remove the temp db from the server once all tests are done
                    _dbContext.Database.EnsureDeleted();
                }

                _disposed = true;
            }
        }
    }

    [CollectionDefinition("Database")]
    public class DatabaseCollection : ICollectionFixture<DbFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}