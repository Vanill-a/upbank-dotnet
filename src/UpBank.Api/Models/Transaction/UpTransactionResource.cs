using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpTransactionResource : UpResource
{
    [JsonPropertyName("attributes")]
    public UpTransactionAttributes Attributes { get; set; }

    [JsonPropertyName("relationships")]
    public UpTransactionRelationships Relationships { get; set; }
}
