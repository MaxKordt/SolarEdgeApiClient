using System.Text.Json.Serialization;

namespace ApiClient;

public record EnergyValue
{
    [JsonPropertyName("date")]
    public string Timestamp { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public double? Value { get; set; } = null;

    public override string ToString() => $"{Timestamp}: {Value}";
}