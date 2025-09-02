using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
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
        
        var siteDetailsResponse = JsonSerializer.Deserialize<SiteDetailsResponse>(jsonContent, _jsonOptions);
        
        return siteDetailsResponse?.Details ?? new SiteDetails();
    }
    
    // Site Details abrufen
    public async Task<SiteDetails[]> GetSitesListAsync()
    {
        var response = await _httpClient.GetAsync($"sites/list?api_key={_apiKey}");
        response.EnsureSuccessStatusCode();
        
        var jsonContent = await response.Content.ReadAsStringAsync();
        
        // TODO geht noch nicht. Ist doch sites das array und count ist eine art index?
        
        var siteDetailsResponse = JsonSerializer.Deserialize<SitesListResponse>(jsonContent, _jsonOptions);
        
        return siteDetailsResponse?.AssociatedSites.Sites ?? [];
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