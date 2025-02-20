using System.Text.Json.Serialization;

namespace UpBank;

public class UpWebhookEventResource
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("attributes")]
    public UpWebhookEventAttributes Attributes { get; set; }

    [JsonPropertyName("relationships")]
    public UpWebhookEventRelationships Relationships { get; set; }
}
