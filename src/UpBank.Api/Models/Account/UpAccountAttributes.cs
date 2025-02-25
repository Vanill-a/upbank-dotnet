using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UpBank.Api;

[JsonConverter(typeof(UpJsonEnumConverter<UpAccountType>))]
public enum UpAccountType
{
    [EnumMember(Value = "SAVER")] Saver,
    [EnumMember(Value = "TRANSACTIONAL")] Transactional,
    [EnumMember(Value = "HOME_LOAN")] HomeLoan,
}

[JsonConverter(typeof(UpJsonEnumConverter<UpOwnershipType>))]
public enum UpOwnershipType
{
    [EnumMember(Value = "INDIVIDUAL")] Individual,
    [EnumMember(Value = "JOINT")] Joint,
}

public class UpAccountAttributes
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("accountType")]
    public UpAccountType AccountType { get; set; }

    [JsonPropertyName("ownershipType")]
    public UpOwnershipType OwnershipType { get; set; }

    [JsonPropertyName("balance")]
    public UpMoney Balance { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
}
