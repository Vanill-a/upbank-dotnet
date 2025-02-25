using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UpBank.Api;

[JsonConverter(typeof(UpJsonEnumConverter<UpWebhookEventType>))]
public enum UpWebhookEventType
{
    [EnumMember(Value = "TRANSACTION_CREATED")] TransactionCreated,
    [EnumMember(Value = "TRANSACTION_SETTLED")] TransactionSettled,
    [EnumMember(Value = "TRANSACTION_DELETED")] TransactionDeleted,
    [EnumMember(Value = "PING")] Ping
}

public class UpWebhookEventAttributes
{
    [JsonPropertyName("eventType")]
    public UpWebhookEventType WebhookEventType { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
}
