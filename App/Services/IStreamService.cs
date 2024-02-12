using LanguageExt;
using LanguageExt.Common;
using Shared.Dtos.Videos;

namespace Services
{
    public interface IStreamService
    {
        Task<Result<string>> GenerateStreamKey(GenerateStreamKeyDto dto);
        Task<Result<VideoSyncDto>> GetVideoStream(string context, DateTimeOffset? momentBefore);
        Task<Result<Unit>> UploadVideoStream(string streamKey, DateTimeOffset moment, long duration, string videoType, MemoryStream videoData);
    }
}