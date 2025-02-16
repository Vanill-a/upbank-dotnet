using System.Text.Json.Serialization;

namespace UpBank;

public class UpAttachmentAttributes
{
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("fileUrl")]
    public string? FileUrl { get; set; }

    [JsonPropertyName("fileURLExpiresAt")]
    public DateTime FileUrlExpiresAt { get; set; }

    [JsonPropertyName("fileExtension")]
    public string? FileExtension { get; set; }

    [JsonPropertyName("fileContentType")]
    public string? FileContentType { get; set; }
}
