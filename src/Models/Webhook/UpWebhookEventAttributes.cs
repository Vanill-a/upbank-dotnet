using System.Text.Json.Serialization;

namespace UpBank;

public enum WebhookEventType
{
    TransactionCreated,
    TransactionSettled,
    TransactionDeleted,
    Ping
}

public class UpWebhookEventAttributes
{
    [JsonPropertyName("eventType")]
    public string WebhookEventType { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
}
