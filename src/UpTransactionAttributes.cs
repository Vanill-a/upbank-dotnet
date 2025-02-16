using System.Text.Json.Serialization;

namespace UpBank;

public enum UpTransactionStatus
{
    Held,
    Settled
}

public class UpTransactionAttributes
{
    [JsonPropertyName("status")]
    public UpTransactionStatus Status { get; set; }
    [JsonPropertyName("rawText")]
    public string RawText { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("message")]
    public string Message { get; set; }
    [JsonPropertyName("isCategorizable")]
    public bool IsCategorizable { get; set; }
    [JsonPropertyName("holdInfo")]
    public UpHoldInfo HoldInfo { get; set; }
    [JsonPropertyName("roundUp")]
    public UpRoundUp RoundUp { get; set; }
    [JsonPropertyName("amount")]
    public UpMoney Amount { get; set; }
    [JsonPropertyName("foreignAmount")]
    public UpMoney ForeignAmount { get; set; }
    [JsonPropertyName("cardPurchaseMethod")]
    public UpCardPurchaseMethod CardPurchaseMethod { get; set; }
    [JsonPropertyName("settledAt")]
    public DateTime SettledAt { get; set; }
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("transactionType")]
    public string TransactionType { get; set; }
    [JsonPropertyName("note")]
    public UpNote Note { get; set; }
    [JsonPropertyName("performingCustomer")]
    public UpCustomer PerformingCustomer { get; set; }
    [JsonPropertyName("deepLinkURL")]
    public string DeepLinkUrl { get; set; }
}
