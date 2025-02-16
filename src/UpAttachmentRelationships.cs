using System.Text.Json.Serialization;

namespace UpBank;

public class UpAttachmentRelationships
{
    [JsonPropertyName("transaction")]
    UpRelationship Transaction { get; set; }
}
