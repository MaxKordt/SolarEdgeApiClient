using System.Text.Json.Serialization;

namespace ApiClient.Models;

public record SitesListResponse
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("site")]
    public SiteDetails[] Sites { get; set; } = [];
    
    override public string ToString() => $"Sites retrieved: {Count}";
}