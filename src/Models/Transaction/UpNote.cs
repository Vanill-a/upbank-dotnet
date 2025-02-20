using System.Text.Json.Serialization;

namespace UpBank;

public class UpNote
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
}
