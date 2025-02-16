using System.Text.Json.Serialization;

namespace UpBank;

public class UpCustomer
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }
}
