using Api.Tools;
using Microsoft.AspNetCore.Mvc;
using Services;
using Shared.Dtos.Videos;
using Shared.Infra.Extensions;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StreamingController : ControllerBase
    {
        private readonly Lazy<IStreamService> _streamService;

        public StreamingController(Lazy<IStreamService> streamService)
        {
            _streamService = streamService;
        }

        [HttpGet("GetStreamKey", Name = "GetStreamKey")]
        public async Task<IActionResult> GetStreamKey([FromQuery] GenerateStreamKeyDto dto)
        {
            var key = await _streamService.Value.GenerateStreamKey(dto);

            return key.ApiResult(d => d);
        }

        [HttpPost("UploadVideoStream", Name = "UploadVideoStream")]
        public async Task<IActionResult> UploadVideoStream(
            [FromHeader] string streamKey,
            [FromHeader] DateTimeOffset moment,
            [FromHeader] long duration,
            [FromHeader] string videoType)
        {
            var item = Request.Form.Files.FirstOrDefault();

            if (item is not null)
            {
                using var memoryStream = new MemoryStream();
                await item.CopyToAsync(memoryStream);

                var result = await _streamService.Value.UploadVideoStream(streamKey, moment, duration, videoType, memoryStream);

                return result.ApiResult(e => e);
            }

            return new BadRequestResult();
        }

        [HttpGet("GetVideoStream", Name = "GetVideoStream")]
        public async Task<FileContentResult> GetVideoStream([FromQuery] string context, DateTimeOffset moment)
        {
            var videoStream = await _streamService.Value.GetVideoStream(context, moment);
            var value = videoStream.GetValue();

            Response.Headers.Append("Content-Type", value.VideoType);
            Response.Headers.Append("moment", value.Moment.ToString()!);
            Response.Headers.Append("duration", value.Duration.ToString()!);

            return File(value.VideoData, value.VideoType);
        }
    }
}
