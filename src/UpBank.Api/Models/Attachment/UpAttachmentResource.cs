using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpAttachmentResource : UpResource
{
    [JsonPropertyName("attributes")]
    public UpAttachmentAttributes Attributes { get; set; }

    [JsonPropertyName("relationships")]
    public UpAttachmentRelationships Relationships { get; set; }
}
