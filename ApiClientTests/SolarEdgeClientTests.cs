using ApiClient;

namespace ApiClientTests;

public class SolarEdgeClientTests
{
    private string _apiKey = Environment.GetEnvironmentVariable("SOLAR_EDGE_API_KEY") ?? "TEST-API-KEY";
    private int _siteId = int.Parse(Environment.GetEnvironmentVariable("SOLAR_EDGE_SITE_ID") ?? "0");

    [Fact]
    public void ConstructorShouldNotThrow()
    {
        const string apiKey = "test-api-key";

        var client = new SolarEdgeClient(apiKey);

        Assert.NotNull(client);
    }

    [Fact]
    public async Task GetSiteDetailsAsync_WithValidSiteId_ShouldReturnSiteDetails()
    {
        // Arrange
        var client = new SolarEdgeClient(_apiKey);

        // Act
        var details = await client.GetSiteDetailsAsync(_siteId);

        // Assert
        Assert.NotNull(details);
    }
}