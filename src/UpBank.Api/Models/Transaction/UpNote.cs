using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpNote
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
}
