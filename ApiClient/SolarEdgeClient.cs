using System.Text.Json;

namespace ApiClient;

public class SolarEdgeClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly JsonSerializerOptions _options;

    public SolarEdgeClient(string apiKey)
    {
        _httpClient = new HttpClient();
        _apiKey = apiKey;
        _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
        
        _httpClient.BaseAddress = new Uri("https://monitoringapi.solaredge.com/");
    }
    
    // Test-Methode um zu prüfen ob API-Key funktioniert
    public async Task<string> GetApiVersionAsync()
    {
        var response = await _httpClient.GetAsync($"version/current?api_key={_apiKey}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    // Dispose Pattern für HttpClient
    public void Dispose()
    {
        _httpClient.Dispose();
    }
}