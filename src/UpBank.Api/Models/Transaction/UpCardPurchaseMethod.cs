using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UpBank.Api;

[JsonConverter(typeof(UpJsonEnumConverter<UpCardPurchaseMethodType>))]
public enum UpCardPurchaseMethodType
{
    [EnumMember(Value = "BAR_CODE")] BarCode,
    [EnumMember(Value = "OCR")] Ocr,
    [EnumMember(Value = "CARD_PIN")] CardPin,
    [EnumMember(Value = "CARD_DETAILS")] CardDetails,
    [EnumMember(Value = "CARD_ON_FILE")] CardOnFile,
    [EnumMember(Value = "ECOMMERCE")] ECommerce,
    [EnumMember(Value = "MAGNETIC_STRIPE")] MagneticStripe,
    [EnumMember(Value = "CONTACTLESS")] Contactless
}

public class UpCardPurchaseMethod
{
    [JsonPropertyName("method")]
    public UpCardPurchaseMethodType Method { get; set; }

    [JsonPropertyName("cardNumberSuffix")]
    public string CardNumberSuffix { get; set; }
}
