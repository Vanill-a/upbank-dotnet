using System.Text.Json.Serialization;

namespace UpBank;

public class UpPageLinks
{
    [JsonPropertyName("prev")]
    public string? Prev { get; set; }
    [JsonPropertyName("next")]
    public string? Next { get; set; }
}
