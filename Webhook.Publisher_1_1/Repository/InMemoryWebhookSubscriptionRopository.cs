using Webhook.Publisher_1_1.Model;

namespace Webhook.Publisher_1_1.Repository
{
    public sealed class InMemoryWebhookSubscriptionRepository
    {
        private readonly List<WebhookSubscription> webhookSubscriptions = [];

        public void Add(WebhookSubscription subscription)
        {
            webhookSubscriptions.Add(subscription);
        }

        public IReadOnlyList<WebhookSubscription> GetByEventType(string eventType)
        {
            return webhookSubscriptions.Where(x => x.EventType == eventType).ToList().AsReadOnly();
        }
    }
}
