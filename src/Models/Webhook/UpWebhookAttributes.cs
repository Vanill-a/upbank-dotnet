using System.Text.Json.Serialization;

namespace UpBank;

public class UpWebhookAttributes
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("secretKey")]
    public string SecretKey { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
}
