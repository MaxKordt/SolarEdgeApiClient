using System.Text.Json.Serialization;

namespace ApiClient.Models;

public class SiteEnergy
{
    [JsonPropertyName("timeUnit")]
    public string TimeUnit { get; set; } = string.Empty;
    
    [JsonPropertyName("unit")]
    public string Unit { get; set; } = string.Empty;
    
    [JsonPropertyName("values")]
    public EnergyValue[] Values { get; set; } = [];
    
    public override string ToString() => $"{TimeUnit}: {Values.Sum(v => v.Value)} {Unit}";
}