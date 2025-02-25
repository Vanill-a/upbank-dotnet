using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpError
{
    [JsonPropertyName("status")]
    public string Status { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("detail")]
    public string Detail { get; set; }
    [JsonPropertyName("source")]
    public UpErrorSource? Source { get; set; }
}
