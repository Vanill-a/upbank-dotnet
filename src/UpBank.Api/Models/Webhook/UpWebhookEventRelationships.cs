using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpWebhookEventRelationships
{
    [JsonPropertyName("webhook")]
    public UpRelationship Webhook { get; set; }

    [JsonPropertyName("transaction")]
    public UpRelationship Transaction { get; set; }
}
