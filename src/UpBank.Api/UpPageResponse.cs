using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpPageResponse<T>
{
    [JsonPropertyName("data")]
    public IEnumerable<T> Data { get; set; }

    [JsonPropertyName("links")]
    public UpPageLinks Links { get; set; }
}
