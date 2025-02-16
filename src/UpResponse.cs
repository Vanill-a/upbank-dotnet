using System.Text.Json.Serialization;

namespace UpBank;

public class UpResponse<T> where T : class
{
    [JsonPropertyName("data")]
    public T Data { get; set; }
}
