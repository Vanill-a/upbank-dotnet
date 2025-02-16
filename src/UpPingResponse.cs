using System.Text.Json.Serialization;

namespace UpBank;

public class UpPingResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("statusEmoji")]
    public string StatusEmoji { get; set; }
}
