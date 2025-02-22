using System.Text.Json.Serialization;

namespace UpBank;

public enum UpCardPurchaseMethodType
{
    BarCode,
    Ocr,
    CardPin,
    CardDetails,
    CardOnFile,
    ECommerce,
    MagneticStripe,
    Contactless
}

public class UpCardPurchaseMethod
{
    [JsonPropertyName("method")]
    public string Method { get; set; }

    [JsonPropertyName("cardNumberSuffix")]
    public string CardNumberSuffix { get; set; }
}
