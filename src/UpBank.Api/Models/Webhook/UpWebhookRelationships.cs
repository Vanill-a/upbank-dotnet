using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpWebhookRelationships
{
    [JsonPropertyName("logs")]
    public UpRelationship Logs { get; set; }
}
