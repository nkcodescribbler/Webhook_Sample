using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace WebhookSubscriber.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebhookSubscriberController : Controller
    {
        [HttpGet]
        public void Get()
        {
            string url = "https://localhost:7013/WebhookSubscriber";
            var client = new HttpClient();
            CreateWebHookRequest request = new CreateWebHookRequest("event.created", url);

            // Serialize the data to JSON
            string json = JsonSerializer.Serialize(request); // Or JsonSerializer.Serialize(data)

            // Convert JSON to HttpContent
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:7154/CallWebHook", content);
        }

        [HttpPost]
        public void Post([FromBody] string text1)
        {

        }
    }
}
