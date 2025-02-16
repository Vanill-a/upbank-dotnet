using System.Text.Json.Serialization;

namespace UpBank;

public class UpWebhookRelationships
{
    [JsonPropertyName("logs")]
    public UpRelationship Logs { get; set; }
}
