using System.Text.Json.Serialization;

namespace UpBank;

public class UpAccountRelationships
{
    [JsonPropertyName("transactions")]
    public UpRelationship Transactions { get; set; }
}
