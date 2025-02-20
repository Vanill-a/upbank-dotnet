using System.Text.Json.Serialization;

namespace UpBank;

public class UpCategoryResource : UpResource
{
    [JsonPropertyName("attributes")]
    public UpCategoryAttributes Attributes { get; set; }
}
