using System.Text.Json;
using ApiClient.Models;

namespace ApiClient;

public class SolarEdgeClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly JsonSerializerOptions _jsonOptions;

    public SolarEdgeClient(string apiKey)
    {
        _httpClient = new HttpClient();
        _apiKey = apiKey;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
        
        _httpClient.BaseAddress = new Uri("https://monitoringapi.solaredge.com/");
    }
    
    // Site Details abrufen
    public async Task<SiteDetails> GetSiteDetailsAsync(int siteId)
    {
        var response = await _httpClient.GetAsync($"site/{siteId}/details?api_key={_apiKey}");
        response.EnsureSuccessStatusCode();
        
        var jsonContent = await response.Content.ReadAsStringAsync();
        
        // Debug: Console output um die echte Response zu sehen
        Console.WriteLine("API Response:");
        Console.WriteLine(jsonContent);
        
        var siteDetailsResponse = JsonSerializer.Deserialize<SiteDetailsResponse>(jsonContent, _jsonOptions);
        
        return siteDetailsResponse?.Details ?? new SiteDetails();
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