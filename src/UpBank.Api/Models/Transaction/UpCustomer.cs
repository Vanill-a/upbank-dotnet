using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpCustomer
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }
}
