using System.Text.Json.Serialization;

namespace UpBank;

public enum UpAccountType
{
    Saver,
    Transactional,
    HomeLoan,
}

public class UpAccountAttributes
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("accountType")]
    public UpAccountType AccountType { get; set; }

    [JsonPropertyName("balance")]
    public UpMoney Balance { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
}
