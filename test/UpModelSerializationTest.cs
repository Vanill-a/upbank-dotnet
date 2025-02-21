using System.Text.Json;

namespace UpBank.Test;

public class UpModelSerializationTest
{
    [Theory]
    [MemberData(nameof(GetSerializationTestData))]
    public void Endpoint_Responses_Deserialize_Correctly(string path, Type type)
    {
        var json = File.ReadAllText(path);
        var result = JsonSerializer.Deserialize(json, type);

        Assert.NotNull(result);
    }

    public static IEnumerable<object[]> GetSerializationTestData()
    {
        var sampledir = Path.Combine(AppContext.BaseDirectory, "Samples");

        yield return new object[] { Path.Combine(sampledir, "AccountPageResponse.json"), typeof(UpPageResponse<UpAccountResource>) };
        yield return new object[] { Path.Combine(sampledir, "AccountResponse.json"), typeof(UpResponse<UpAccountResource>) };
        yield return new object[] { Path.Combine(sampledir, "AttachmentPageResponse.json"), typeof(UpPageResponse<UpAttachmentResource>) };
        yield return new object[] { Path.Combine(sampledir, "AttachmentResponse.json"), typeof(UpResponse<UpAttachmentResource>) };
        yield return new object[] { Path.Combine(sampledir, "CategoryPageResponse.json"), typeof(UpPageResponse<UpCategoryResource>) };
        yield return new object[] { Path.Combine(sampledir, "CategoryResponse.json"), typeof(UpResponse<UpCategoryResource>) };
        yield return new object[] { Path.Combine(sampledir, "ErrorResponse.json"), typeof(UpErrorResponse) };
        yield return new object[] { Path.Combine(sampledir, "PingResponse.json"), typeof(UpPingResponse) };
        yield return new object[] { Path.Combine(sampledir, "TagPageResponse.json"), typeof(UpPageResponse<UpTagResource>) };
        yield return new object[] { Path.Combine(sampledir, "TransactionPageResponse.json"), typeof(UpPageResponse<UpTransactionResource>) };
        yield return new object[] { Path.Combine(sampledir, "TransactionResponse.json"), typeof(UpResponse<UpTransactionResource>) };
        yield return new object[] { Path.Combine(sampledir, "WebhookDeliveryLogPageResponse.json"), typeof(UpPageResponse<UpWebhookDeliveryLogResource>) };
        yield return new object[] { Path.Combine(sampledir, "WebhookEventResponse.json"), typeof(UpResponse<UpWebhookEventResource>) };
        yield return new object[] { Path.Combine(sampledir, "WebhookPageResponse.json"), typeof(UpPageResponse<UpWebhookResource>) };
        yield return new object[] { Path.Combine(sampledir, "WebhookResponse.json"), typeof(UpResponse<UpWebhookResource>) };
    }
}
