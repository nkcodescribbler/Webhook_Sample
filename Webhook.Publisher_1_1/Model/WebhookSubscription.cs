namespace Webhook.Publisher_1_1.Model
{
    public sealed record WebhookSubscription(Guid id, string EventType, string WebhookURL, DateTime createOnUtc);
    public sealed record CreateWebHookRequest(string EventType, string WebhookURL);
}
