using System.Text.Json.Serialization;
using ApiClient.Models;

namespace ApiClient.Responses;

public record SitesListResponse
{
    [JsonPropertyName("sites")]
    public SitesList AssociatedSites { get; set; } = new();
    
    public override string ToString() => $"Associated Sites: {AssociatedSites.Sites.Length}";
}