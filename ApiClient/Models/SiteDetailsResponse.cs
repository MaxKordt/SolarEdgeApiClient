using System.Text.Json.Serialization;

namespace ApiClient.Models;

public record SiteDetailsResponse
{
    [JsonPropertyName("details")] 
    public SiteDetails Details { get; set; } = new();
}