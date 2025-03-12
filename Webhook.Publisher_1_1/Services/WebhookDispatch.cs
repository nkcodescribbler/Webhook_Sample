using System.Text.Json;
using Webhook.Publisher_1_1.Repository;

namespace Webhook.Publisher_1_1.Services
{
    public sealed class WebhookDispatcher(HttpClient httpClient,
        InMemoryWebhookSubscriptionRepository subscriptionRopository)
    {
        public async Task DispachAsync(string eventType, string payload)
        {
            var subscriptions = subscriptionRopository.GetByEventType(eventType);

            foreach (var subscription in subscriptions)
            {
                var request = new
                {
                    Id = Guid.NewGuid(),
                    subscription.EventType,
                    SubscriptionId = subscription.id,
                    Timestamp = DateTime.Now,
                    Data = payload
                };

                await httpClient.PostAsJsonAsync(subscription.WebhookURL, JsonSerializer.Serialize(request));
            }
        }
    }
}
