using System.Text.Json.Serialization;

namespace UpBank;

public class UpHoldInfo
{
    [JsonPropertyName("amount")]
    public UpMoney Amount { get; set; }
    [JsonPropertyName("foreignAmount")]
    public UpMoney ForeignAmount { get; set; }
}
