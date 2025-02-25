using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpCategoryAttributes
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
