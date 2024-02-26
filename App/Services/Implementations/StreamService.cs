using Database;
using Domain.Entities;
using LanguageExt;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Videos;
using Shared.Infra.Helpers;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Services.Implementations
{
    internal class StreamService : IStreamService
    {
        private readonly CachedContext _cachedContext;

        public StreamService(CachedContext cachedContext)
        {
            _cachedContext = cachedContext;
        }

        public async Task<Result<string>> GenerateStreamKey(GenerateStreamKeyDto dto)
        {
            if (dto.UserId == Guid.Empty)
            {
                return new Result<string>(new ValidationException("'User' invalid."));
            }

            var key = StreamKeyHelper.GenerateStreamKey();

            var streamKey = new StreamKey
            {
                Key = key,
                UserId = dto.UserId,
                Context = dto.Context
            };

            await _cachedContext.AddAsync(streamKey);
            await _cachedContext.SaveChangesAsync();

            return new Result<string>(key);
        }

        public async Task<Result<Unit>> UploadVideoStream(string streamKey, DateTimeOffset moment, long duration, string videoType, MemoryStream videoData)
        {
            if (IsVideoTooLarge(videoData))
            { 
                return new Result<Unit>(new ValidationException("Video size is too large."));
            }

            if (!IsVideoTypeValid(videoType))
            {
                return new Result<Unit>(new ValidationException("Video type is invalid."));
            }

            streamKey = GetStreamKeyFormated(streamKey);

            if (!await IsStreamKeyValid(streamKey))
            {
                return new Result<Unit>(new ValidationException("'Stream key' is invalid."));
            }

            var videoStructured = new VideoStructure
            {
                Id = Guid.NewGuid(),
                StreamKey = streamKey,
                Moment = moment,
                Duration = GetDuration(duration),
                VideoType = videoType,
                VideoData = videoData.ToArray()
            };

            await _cachedContext.AddAsync(videoStructured);

            await _cachedContext.SaveChangesAsync();

            return new Result<Unit>();
        }

        public async Task<Result<VideoSyncDto>> GetVideoStream(string context, DateTimeOffset? momentBefore)
        {
            var streamKey = await _cachedContext.Set<StreamKey>().FirstOrDefaultAsync(x => x.Context == context);

            if (streamKey == null)
            {
                return new Result<VideoSyncDto>(new ValidationException("'Stream key' not found."));
            }

            var query = _cachedContext.Set<VideoStructure>().Where(x => x.StreamKey == streamKey.Key);

            if (momentBefore.HasValue)
            {
                query = query.Where(x => x.Moment > momentBefore).OrderBy(x => x.Moment);
            }
            else
            {
                query = query.OrderByDescending(x => x.Moment);
            }

            var video = await query.FirstOrDefaultAsync();

            if (video == null)
            {
                return new Result<VideoSyncDto>(new ValidationException("'Video' not found."));
            }

            return new Result<VideoSyncDto>(new VideoSyncDto
            {
                Moment = video.Moment,
                Duration = video.Duration,
                VideoData = video.VideoData,
                VideoType = video.VideoType
            });
        }

        private static string GetStreamKeyFormated(string streamKey)
        {
            return streamKey.Trim();
        }

        private async Task<bool> IsStreamKeyValid(string streamKey)
        {
            return !string.IsNullOrWhiteSpace(streamKey)
                && await _cachedContext.Set<StreamKey>().AnyAsync(c => c.Key == streamKey);
        }

        private static TimeSpan GetDuration(long duration)
        {
            return TimeSpan.FromMilliseconds(duration);
        }

        private static bool IsVideoTypeValid(string videoType)
        {
            return videoType == "video/mp4" || videoType == "video/ogg" || videoType == "video/webm";
        }
        
        private static bool IsVideoTooLarge(Stream videoData)
        {
            return GetMbSize(videoData) > 10;
        }

        private static float GetMbSize(Stream videoData)
        {
            return videoData.Length / 1024f / 1024f;
        }
    }
}
