using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpWebhookResource : UpResource
{
    [JsonPropertyName("attributes")]
    public UpWebhookAttributes Attributes { get; set; }

    [JsonPropertyName("relationships")]
    public UpWebhookRelationships Relationships { get; set; }
}
