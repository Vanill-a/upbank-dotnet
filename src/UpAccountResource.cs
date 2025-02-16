using System.Text.Json.Serialization;

namespace UpBank;

public class UpAccountResource : UpResource
{
    [JsonPropertyName("type")]
    public string AccountType { get; set; }
    [JsonPropertyName("id")]
    public string Id { get; set; }
}
