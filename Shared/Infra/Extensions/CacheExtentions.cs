using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Shared.Infra.Extensions
{
    public static class CacheExtentions
    {
        public static Task SetAsync<T>(this IDistributedCache cache, string key, T? value)
        {
            var stringObject = value is not null ? JsonSerializer.Serialize(value) : string.Empty;

            return cache.SetStringAsync(key, stringObject);
        }

        public static async Task<T?> GetAsync<T>(this IDistributedCache cache, string key)
        {
            var stringObject = await cache.GetStringAsync(key);

            return !string.IsNullOrEmpty(stringObject) ? JsonSerializer.Deserialize<T>(stringObject) : default;
        }
    }
}
