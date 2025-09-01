using System.Text.Json.Serialization;

namespace ApiClient.Models;

public record PrimaryModule
{
    [JsonPropertyName("manufacturerName")]
    public string ManufacturerName { get; set; } = string.Empty;
    
    [JsonPropertyName("modelName")]
    public string ModelName { get; set; } = string.Empty;
    
    [JsonPropertyName("maximumPower")]
    public double MaximumPower { get; set; }
    
    [JsonPropertyName("temperatureCoef")]
    public double TemperatureCoefficient { get; set; }

    public override string ToString() => ModelName;
}