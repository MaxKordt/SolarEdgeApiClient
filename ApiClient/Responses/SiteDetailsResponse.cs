using System.Text.Json.Serialization;
using ApiClient.Models;

namespace ApiClient.Responses;

public record SiteDetailsResponse
{
    [JsonPropertyName("details")] 
    public SiteDetails Details { get; set; } = new();
}