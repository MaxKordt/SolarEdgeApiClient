using System.Text.Json.Serialization;

namespace ApiClient.Models;

public class Uris
{
    [JsonPropertyName("DETAILS")]
    public string Details { get; set; } = string.Empty;
    
    [JsonPropertyName("DATA_PERIOD")]
    public string DataPeriod { get; set; } = string.Empty;
    
    [JsonPropertyName("OVERVIEW")]
    public string Overview { get; set; } = string.Empty;
    
    [JsonPropertyName("SITE_IMAGE")]
    public string SiteImage { get; set; } = string.Empty;
}