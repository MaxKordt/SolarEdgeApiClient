using ApiClient;

namespace ApiClientTests;

public class SolarEdgeClientTests
{
    [Fact]
    public void ConstructorShouldNotThrow()
    {
        const string apiKey = "test-api-key";
        
        var client = new SolarEdgeClient(apiKey);
        
        Assert.NotNull(client);
    }
}