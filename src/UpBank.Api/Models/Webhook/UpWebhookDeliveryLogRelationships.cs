using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpWebhookDeliveryLogRelationships
{
    [JsonPropertyName("webhookEvent")]
    public UpRelationship WebhookEvent { get; set; }
}
