using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpResource
{
    [JsonPropertyName("type")]
    public string ResourceType { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("links")]
    public UpLinks Links { get; set; }
}
