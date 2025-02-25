using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpWebhookDeliveryLogResource
{
    [JsonPropertyName("attributes")]
    public UpWebhookDeliveryLogAttributes Attributes { get; set; }

    [JsonPropertyName("relationships")]
    public UpWebhookDeliveryLogRelationships Relationships { get; set; }
}
