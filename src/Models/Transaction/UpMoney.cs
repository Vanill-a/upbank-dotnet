using System.Text.Json.Serialization;

namespace UpBank;

public class UpMoney
{
    [JsonPropertyName("currencyCode")]
    public string CurrencyCode { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("valueInBaseUnits")]
    public int ValueInBaseUnits { get; set; }
}
