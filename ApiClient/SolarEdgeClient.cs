using System.Text.Json;
using ApiClient.Models;
using ApiClient.Responses;

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

    public async Task<SiteDetails> GetSiteDetailsAsync(int siteId)
    {
        var response = await _httpClient.GetAsync($"site/{siteId}/details?api_key={_apiKey}");
        response.EnsureSuccessStatusCode();

        var jsonContent = await response.Content.ReadAsStringAsync();

        var siteDetailsResponse = JsonSerializer.Deserialize<SiteDetailsResponse>(jsonContent, _jsonOptions);

        return siteDetailsResponse?.Details ?? new SiteDetails();
    }

    public async Task<SiteDetails[]> GetSitesListAsync()
    {
        var response = await _httpClient.GetAsync($"sites/list?api_key={_apiKey}");
        response.EnsureSuccessStatusCode();

        var jsonContent = await response.Content.ReadAsStringAsync();

        var siteDetailsResponse = JsonSerializer.Deserialize<SitesListResponse>(jsonContent, _jsonOptions);

        return siteDetailsResponse?.AssociatedSites.Sites ?? [];
    }

    public async Task<SiteEnergy> GetSiteEnergyAsync(int siteId, RequestSpan requestSpan)
    {
        var request =
            $"site/{siteId}/energy?timeUnit={requestSpan.TimeUnit.ToParam()}&startDate={requestSpan.StartDate.ToEnergyParam()}&endDate={requestSpan.EndDate.ToEnergyParam()}&api_key={_apiKey}";
        var response = await _httpClient.GetAsync(request);
        response.EnsureSuccessStatusCode();

        var jsonContent = await response.Content.ReadAsStringAsync();

        var siteDetailsResponse = JsonSerializer.Deserialize<SiteEnergyResponse>(jsonContent, _jsonOptions);

        return siteDetailsResponse?.Energy ?? new SiteEnergy();
    }

    // Dispose Pattern für HttpClient
    public void Dispose()
    {
        _httpClient.Dispose();
    }
}