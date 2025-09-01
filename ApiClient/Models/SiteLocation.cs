using System.Text.Json.Serialization;

namespace ApiClient.Models;

public record SiteLocation
{
    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;
    
    [JsonPropertyName("city")]
    public string? City { get; set; }
    
    [JsonPropertyName("state")]
    public string? State { get; set; }
    
    [JsonPropertyName("address")]
    public string Address { get; set; } = string.Empty;
    
    [JsonPropertyName("address2")]
    public string? Address2 { get; set; }
    
    [JsonPropertyName("zip")]
    public string? Zip { get; set; }
    
    [JsonPropertyName("timeZone")]
    public string TimeZone { get; set; } = string.Empty;
    
    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; } = string.Empty;
    
    [JsonPropertyName("latitude")]
    public string Latitude { get; set; } = string.Empty;
    
    [JsonPropertyName("longitude")]
    public string Longitude { get; set; } = string.Empty;
}