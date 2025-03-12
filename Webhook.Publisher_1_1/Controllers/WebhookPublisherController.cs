using Microsoft.AspNetCore.Mvc;
using Webhook.Publisher_1_1.Model;
using Webhook.Publisher_1_1.Repository;
using Webhook.Publisher_1_1.Services;

namespace Webhook.Publisher_1_1.Controllers
{
    public class WebhookPublisherController : Controller
    {
        InMemoryWebhookSubscriptionRepository subscriptionRepository;
        WebhookDispatcher webhookDispatcher;
        public WebhookPublisherController(InMemoryWebhookSubscriptionRepository _subscriptionRopository,
            WebhookDispatcher _webhookDispatcher)
        {
            subscriptionRepository = _subscriptionRopository;
            webhookDispatcher = _webhookDispatcher;
        }

        [HttpPost("CallWebHook")]
        public IActionResult Post([FromBody] CreateWebHookRequest request)
        {
            WebhookSubscription subscription = new WebhookSubscription(
               Guid.NewGuid(),
               request.EventType,
               request.WebhookURL,
               DateTime.UtcNow
               );

            subscriptionRepository.Add(subscription);
            webhookDispatcher.DispachAsync(request.EventType, "Order hasd been created");
            return Ok();
        }
    }
}
