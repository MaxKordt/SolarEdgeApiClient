using System.Text.Json.Serialization;

namespace ApiClient.Models;

public record SitesListResponse
{
    [JsonPropertyName("sites")]
    public SitesList AssociatedSites { get; set; } = new();
    
    public override string ToString() => $"Associated Sites: {AssociatedSites.Sites.Length}";
}