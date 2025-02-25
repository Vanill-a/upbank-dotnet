using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpRelationship
{
    [JsonPropertyName("data")]
    public UpRelationshipData Data { get; set; }
    [JsonPropertyName("links")]
    public UpLinks Links { get; set; }
}
