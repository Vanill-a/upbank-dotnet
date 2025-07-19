using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpWebhookInputResource
{
    public UpWebhookInputResource(
        UpWebhookInputAttributes? attributes = null)
    {
        this.Attributes = attributes ?? new UpWebhookInputAttributes();
    }

    [JsonPropertyName("attributes")]
    public UpWebhookInputAttributes Attributes { get; set; }
}
