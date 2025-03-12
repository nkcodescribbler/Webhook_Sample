namespace WebhookSubscriber
{
    public sealed record CreateWebHookRequest(string EventType, string WebhookURL);
}
