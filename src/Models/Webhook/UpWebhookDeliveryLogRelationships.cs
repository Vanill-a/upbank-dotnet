using System.Text.Json.Serialization;

namespace UpBank;

public class UpWebhookDeliveryLogRelationships
{
    [JsonPropertyName("webhookEvent")]
    public UpRelationship WebhookEvent { get; set; }
}
