using Microsoft.Extensions.Caching.Distributed;
using Shared.Infra;
using Shared.Infra.Extensions;
using Shared.Infra.Helpers;

namespace Shared.Querys.Implementations
{
    internal class QueryCachedParams<D> : IQueryCachedParams<D>
    {
        public readonly Lazy<IDistributedCache> Cache;
        public readonly Lazy<IQueryGuid<D>> Query;

        public QueryCachedParams(Lazy<IDistributedCache> cache, Lazy<IQueryGuid<D>> query)
        {
            Cache = cache;
            Query = query;
        }
    }

    public abstract class QueryCached<D> : IQueryCached<D>
        where D : IPrimaryKey
    {
        private readonly Lazy<IDistributedCache> _cache;
        private readonly Lazy<IQueryGuid<D>> _query;

        protected QueryCached(IQueryCachedParams<D> queryParams)
        {
            var param = (QueryCachedParams<D>)queryParams;

            _cache = param.Cache;
            _query = param.Query;
        }

        public async Task<D?> GetAsyncCached(string id)
        {
            var guid = PrimaryKeyHelper.ValidateIdGetGuid(id);
            var result = await _cache.Value.GetAsync<D>(guid);

            result ??= await _query.Value.GetAsync(guid);

            return result;
        }
    }
}
