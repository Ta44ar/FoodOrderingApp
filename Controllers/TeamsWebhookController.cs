using FoodOrderingApp.Models.Webhook_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsWebhookController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<TeamsWebhookController> _logger;

        public TeamsWebhookController(IHttpClientFactory clientFactory, ILogger<TeamsWebhookController> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        [HttpPost("send-notification")]
        public async Task<IActionResult> SendNotificationAsync([FromBody] TeamsNotification notification)
        {
            try
            {
                string webhookUrl = "webhookb2/15a81865-9d35-4543-bddc-cf19926f993c@f211e924-b657-49c8-91af-32ca3d96f706/IncomingWebhook/c9f5edee28524c74b3ad099482709c8c/eef5365d-011e-4892-adc6-e9afc3910450";

                string jsonPayload = JsonSerializer.Serialize(notification);

                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var client = _clientFactory.CreateClient("WebClient");

                var response = await client.PostAsync(webhookUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok("Notification sent successfully.");
                }
                else
                {
                    _logger.LogError($"Failed to send notification. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}");
                    return StatusCode((int)response.StatusCode, "Failed to send notification.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending the notification.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
