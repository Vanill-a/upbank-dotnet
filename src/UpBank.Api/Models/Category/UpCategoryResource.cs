using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpCategoryResource : UpResource
{
    [JsonPropertyName("attributes")]
    public UpCategoryAttributes Attributes { get; set; }
}
