using System.Text.Json.Serialization;

namespace UpBank;

public class UpLinks
{
    [JsonPropertyName("related")]
    public string? Related { get; set; }
    [JsonPropertyName("self")]
    public string? Self { get; set; }
}
