using FluentAssertions;
using UuidMasterApi.Controllers;
using UuidMasterApi.Entities;
using UuidMasterApi.Models;
using UuidMasterApi.Tests;
using Xunit;

namespace UuidMasterApiTests.Controllers
{
    [Collection("Database")]
    public sealed class ResourcesControllerTests : IClassFixture<ApiWebApplicationFactory>
    {
        private readonly ApiWebApplicationFactory _factory;

        public ResourcesControllerTests(ApiWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/resources")]
        public async Task GetResources_Returns200(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
        }
    }
}