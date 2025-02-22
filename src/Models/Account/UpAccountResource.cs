using System.Text.Json.Serialization;

namespace UpBank;

public class UpAccountResource : UpResource
{
    [JsonPropertyName("attributes")]
    public UpAccountAttributes Attributes { get; set; }

    [JsonPropertyName("relationships")]
    public UpAccountRelationships Relationships { get; set; }
}
