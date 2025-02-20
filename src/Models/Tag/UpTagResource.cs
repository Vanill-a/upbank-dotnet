using System.Text.Json.Serialization;

namespace UpBank;

public class UpTagResource : UpResource
{
    [JsonPropertyName("relationships")]
    UpTagRelationships Relationships { get; set; }
}
