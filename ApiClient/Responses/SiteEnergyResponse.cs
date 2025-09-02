using System.Text.Json.Serialization;
using ApiClient.Models;

namespace ApiClient.Responses;

public class SiteEnergyResponse
{
    [JsonPropertyName("energy")]
    public SiteEnergy Energy { get; set; } = new();
}