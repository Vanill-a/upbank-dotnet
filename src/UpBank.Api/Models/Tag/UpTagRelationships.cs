using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpTagRelationships
{
    [JsonPropertyName("transaction")]
    public UpRelationship Transactions { get; set; }
}
