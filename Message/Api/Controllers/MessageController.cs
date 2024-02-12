using Api.Tools;
using Microsoft.AspNetCore.Mvc;
using Querys.Messages;
using Services.Messages;
using Shared.Dtos.Interactions.Messages;
using Shared.Infra;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController
    {
        private readonly Lazy<IBuilder<IMessageService>> _messageServiceBuilder;
        private readonly Lazy<IBuilder<IMessageQuery>> _messageQueryBuilder;

        public MessageController(Lazy<IBuilder<IMessageService>> messageServiceBuilder, Lazy<IBuilder<IMessageQuery>> messageQueryBuilder)
        {
            _messageServiceBuilder = messageServiceBuilder;
            _messageQueryBuilder = messageQueryBuilder;
        }

        [HttpGet("Get", Name = "Get")]
        public async Task<IActionResult> GetAsync(string context, string id)
        {
            var result = await _messageQueryBuilder.Value.Build(context).GetAsync(id);
            return result.ApiResult(u => u);
        }

        [HttpGet("GetAllAfter", Name = "GetAllAfter")]
        public async Task<IActionResult> GetAllAfterAsync(string context, DateTimeOffset baseTime)
        {
            var result = await _messageQueryBuilder.Value.Build(context).GetAllAfterAsync(baseTime);
            return new OkObjectResult(result);
        }

        [HttpPost("SendMessage", Name = "SendMessage")]
        public async Task<IActionResult> SendMessageAsync([FromQuery] string context, [FromBody] MessageDto message)
        {
            var result = await _messageServiceBuilder.Value.Build(context).CreateAsync(message);
            return result.ApiResult(u => u);
        }

        [HttpPut("Update", Name = "Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] string context, [FromBody] MessageDto message)
        {
            var result = await _messageServiceBuilder.Value.Build(context).UpdateAsync(message);
            return result.ApiResult(u => u);
        }

        [HttpDelete("Delete", Name = "Delete")]
        public async Task<IActionResult> DeleteAsync(string context, string id)
        {
            var result = await _messageServiceBuilder.Value.Build(context).DeleteAsync(id);
            return result.ApiResult(u => u);
        }
    }
}
