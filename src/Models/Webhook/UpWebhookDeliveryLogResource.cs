using System.Text.Json.Serialization;

namespace UpBank;

public class UpWebhookDeliveryLogResource
{
    [JsonPropertyName("attributes")]
    public UpWebhookDeliveryLogAttributes Attributes { get; set; }

    [JsonPropertyName("relationships")]
    public UpWebhookDeliveryLogRelationships Relationships { get; set; }
}
