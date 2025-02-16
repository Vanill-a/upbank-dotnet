using System.Text.Json.Serialization;

namespace UpBank;

public class UpPageResponse<T> where T : class
{
    [JsonPropertyName("data")]
    public IEnumerable<T> Data { get; set; }

    [JsonPropertyName("links")]
    public UpPageLinks Links { get; set; }
}
