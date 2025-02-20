using System.Text.Json.Serialization;

namespace UpBank;

public class UpRoundUp
{
    [JsonPropertyName("amount")]
    public UpMoney Amount { get; set; }
    [JsonPropertyName("boostPortion")]
    public UpMoney BoostPortion { get; set; }
}
