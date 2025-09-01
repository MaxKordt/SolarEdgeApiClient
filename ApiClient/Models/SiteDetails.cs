using System;
using System.Text.Json.Serialization;

namespace ApiClient.Models;

public class SiteDetails
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("accountId")]
    public int AccountId { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("peakPower")]
    public double PeakPower { get; set; }
    
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;
    
    [JsonPropertyName("lastUpdateTime")]
    public DateTime LastUpdateTime { get; set; }

    [JsonPropertyName("installationDate")]
    public DateTime InstallationDate { get; set; }

    [JsonPropertyName("ptoDate")]
    public string? PtoDate { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("location")]
    public SiteLocation Location { get; set; } = new();
    
    [JsonPropertyName("primaryModule")]
    public PrimaryModule PrimaryModule { get; set; } = new();
    
    [JsonPropertyName("alertQuantity")]
    public int AlertQuantity { get; set; }
    
    [JsonPropertyName("alertSeverity")]
    public string AlertSeverity { get; set; } = string.Empty;
    
    [JsonPropertyName("highestImpact")]
    public string HighestImpact { get; set; } = string.Empty;
    
    [JsonPropertyName("uris")]
    public Uris Uris { get; set; } = new();

    [JsonPropertyName("publicSettings")]
    public PublicSettings PublicSettings { get; set; } = new();
}