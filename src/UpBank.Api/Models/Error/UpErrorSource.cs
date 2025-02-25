using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpErrorSource
{
    [JsonPropertyName("parameter")]
    public string? Parameter { get; set; }
    [JsonPropertyName("pointer")]
    public string? Pointer { get; set; }
}
