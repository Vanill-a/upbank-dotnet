using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpErrorResponse
{
    [JsonPropertyName("errors")]
    public IEnumerable<UpError> Errors { get; set; }
}
