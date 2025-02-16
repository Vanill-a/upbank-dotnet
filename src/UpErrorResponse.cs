using System.Text.Json.Serialization;

namespace UpBank;

public class UpErrorResponse
{
    [JsonPropertyName("errors")]
    public IEnumerable<UpError> Errors { get; set; }
}
