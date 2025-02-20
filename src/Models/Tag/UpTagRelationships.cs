using System.Text.Json.Serialization;

namespace UpBank;

public class UpTagRelationships
{
    [JsonPropertyName("transaction")]
    public UpRelationship Transactions { get; set; }
}
