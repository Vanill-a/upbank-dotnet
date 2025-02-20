using System.Text.Json.Serialization;

namespace UpBank;

public enum WebhookDeliveryStatus
{
    Delivered,
    Undeliverable,
    BadResponseCode,
}

public class UpWebhookDeliveryLogAttributes
{
    [JsonPropertyName("request")]
    public UpWebhookRequest Request { get; set; }

    [JsonPropertyName("response")]
    public UpWebhookResponse Response { get; set; }

    [JsonPropertyName("deliveryStatus")]
    public string DeliveryStatus { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
}

public class UpWebhookRequest
{
    [JsonPropertyName("body")]
    public string Body { get; set; }
}

public class UpWebhookResponse
{
    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; }
}
