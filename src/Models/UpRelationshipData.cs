using System.Text.Json.Serialization;

namespace UpBank;

public class UpRelationshipData
{
    public UpRelationshipData()
    {
        this.Type = string.Empty;
        this.Id = string.Empty;
    }
    
    public UpRelationshipData(string type, string id)
    {
        this.Type = type;
        this.Id = id;
    }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }
}
