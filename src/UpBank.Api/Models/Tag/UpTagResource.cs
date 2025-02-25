using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpTagResource : UpResource
{
    [JsonPropertyName("relationships")]
    UpTagRelationships Relationships { get; set; }
}
