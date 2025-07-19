using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpWebhookInputAttributes
{
    public UpWebhookInputAttributes()
        : this(string.Empty)
    {

    }

    public UpWebhookInputAttributes(
        string url, string? description = null)
    {
        this.Url = url;
        this.Description = description;
    }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
