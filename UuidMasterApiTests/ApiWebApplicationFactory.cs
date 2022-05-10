using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace UuidMasterApi.Tests
{
    [Collection("Database")]
    public class ApiWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly DbFixture _dbFixture;

        public ApiWebApplicationFactory(DbFixture dbFixture)
            => _dbFixture = dbFixture;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");
            
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:UuidMasterApiDbConnectionString", _dbFixture.ConnectionString)
                });
            });
        }
    }
}