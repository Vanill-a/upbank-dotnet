using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpResponse<T> where T : class
{
    [JsonPropertyName("data")]
    public T Data { get; set; }
}
