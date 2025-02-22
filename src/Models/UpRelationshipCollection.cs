using System.Text.Json.Serialization;

namespace UpBank;

public class UpRelationshipCollection
{
    [JsonPropertyName("data")]
    public IEnumerable<UpRelationshipData> Data { get; set; }

    [JsonPropertyName("links")]
    public UpLinks Links { get; set; }
}
