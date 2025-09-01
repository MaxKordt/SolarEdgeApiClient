using System.Text.Json.Serialization;

namespace ApiClient.Models;

public record PublicSettings
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("isPublic")]
    public bool? IsPublic { get; set; }
}