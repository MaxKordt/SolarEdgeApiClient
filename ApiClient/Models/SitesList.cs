using System.Text.Json.Serialization;

namespace ApiClient.Models;

public record SitesList
{
    [JsonPropertyName("count")]
    public int Count { get; set; } = 0;

    [JsonPropertyName("site")]
    public SiteDetails[] Sites { get; set; } = [];

    public override string ToString() => $"Sites retrieved: {Count}";
}