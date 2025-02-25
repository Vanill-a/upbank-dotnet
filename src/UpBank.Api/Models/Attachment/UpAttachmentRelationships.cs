using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpAttachmentRelationships
{
    [JsonPropertyName("transaction")]
    UpRelationship Transaction { get; set; }
}
