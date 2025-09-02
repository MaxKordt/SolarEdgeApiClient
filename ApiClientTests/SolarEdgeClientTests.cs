using ApiClient;

namespace ApiClientTests;

public class SolarEdgeClientTests
{
    private readonly string _apiKey = Environment.GetEnvironmentVariable("SOLAR_EDGE_API_KEY") ?? "TEST-API-KEY";
    private readonly int _siteId = int.Parse(Environment.GetEnvironmentVariable("SOLAR_EDGE_SITE_ID") ?? "0");
    
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

    [Fact]
    public async Task GetSitesListShouldRetrieveSite()
    {
        // Arrange
        var client = new SolarEdgeClient(_apiKey);

        // Act
        var sites = await client.GetSitesListAsync();

        // Assert
        Assert.NotEmpty(sites);
    }

    [Fact]
    public async Task GetSiteEnergyShouldRetrieveEnergy()
    {
        // Arrange
        var client = new SolarEdgeClient(_apiKey);
        var requestSpan = RequestSpan.GetDay(new DateTime(2025, 09, 1));
        
        // Act
        var energy = await client.GetSiteEnergyAsync(_siteId, requestSpan);

        // Assert
        Assert.NotEmpty(energy.Values);
    }
}