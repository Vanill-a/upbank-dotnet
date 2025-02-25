using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpAccountRelationships
{
    [JsonPropertyName("transactions")]
    public UpRelationship Transactions { get; set; }
}
