using FoodOrderingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FoodOrderingApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class MessageCardController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<MessageCardController> _logger;
        private static readonly string DefaultWebhookUrl = "https://eclipse822.webhook.office.com/webhookb2/15a81865-9d35-4543-bddc-cf19926f993c@f211e924-b657-49c8-91af-32ca3d96f706/IncomingWebhook/c9f5edee28524c74b3ad099482709c8c/eef5365d-011e-4892-adc6-e9afc3910450";

        public MessageCardController(IHttpClientFactory httpClientFactory, ILogger<MessageCardController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> SendMessageAsync([FromBody] MessageEntity messageEntity)
        {
            if (string.IsNullOrEmpty(messageEntity.WebhookUrl))
            {
                return BadRequest("Webhook URL cannot be empty.");
            }

            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(messageEntity.MessageBody, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(messageEntity.WebhookUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok("Message sent successfully.");
                }
                else
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Failed to send message. Status Code: {response.StatusCode}, Response: {responseBody}");
                    return StatusCode((int)response.StatusCode, "Failed to send message.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending the message.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Save")]
        public async Task<IActionResult> SendResponse([FromBody] ResponseEntity responseEntity)
        {
            if (string.IsNullOrEmpty(responseEntity.Comment))
            {
                return BadRequest("Comment cannot be empty.");
            }

            var cardJson = JsonSerializer.Serialize(new
            {
                @type = "MessageCard",
                summary = "Response Message",
                sections = new[]
                {
                    new
                    {
                        activityTitle = "Welcome Message",
                        text = $"Submitted response: {responseEntity.Comment}"
                    }
                }
            });

            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(cardJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(DefaultWebhookUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok("Response sent successfully.");
                }
                else
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Failed to send response. Status Code: {response.StatusCode}, Response: {responseBody}");
                    return StatusCode((int)response.StatusCode, "Failed to send response.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending the response.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
