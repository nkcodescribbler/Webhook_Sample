using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace WebhookSubscriber.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public void Get()
        {
            string url = "https://localhost:7013/WeatherForecast";
            var client = new HttpClient();
            CreateWebHookRequest request = new CreateWebHookRequest("event.updated", url);

            // Serialize the data to JSON
            string json = JsonSerializer.Serialize(request); // Or JsonSerializer.Serialize(data)

            // Convert JSON to HttpContent
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:7154/CallWebHook", content);
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public void Post([FromBody] string text1)
        {

        }
    }
}
