using System.Text.Json.Serialization;

namespace UpBank;

public class UpTransactionRelationships
{
    [JsonPropertyName("account")]
    public UpRelationship Account { get; set; }

    [JsonPropertyName("transferAccount")]
    public UpRelationship TransferAccount { get; set; }

    [JsonPropertyName("category")]
    public UpRelationship Category { get; set; }

    [JsonPropertyName("parentCategory")]
    public UpRelationship ParentCategory { get; set; }

    [JsonPropertyName("tags")]
    public UpRelationshipCollection Tags { get; set; }

    [JsonPropertyName("attachment")]
    public UpRelationship Attachment { get; set; }
}
