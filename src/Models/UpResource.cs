using System.Text.Json.Serialization;

namespace UpBank;

public class UpResource
{
    [JsonPropertyName("type")]
    public string ResourceType { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("links")]
    public UpLinks Links { get; set; }
}
