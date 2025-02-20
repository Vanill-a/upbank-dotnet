using System.Text.Json.Serialization;

namespace UpBank;

public class UpCategoryAttributes
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
