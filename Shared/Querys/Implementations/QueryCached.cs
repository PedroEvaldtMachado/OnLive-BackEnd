using LanguageExt.Common;
using Microsoft.Extensions.Caching.Distributed;
using Shared.Infra;
using Shared.Infra.Extensions;
using Shared.Infra.Helpers;

namespace Shared.Querys.Implementations
{
    internal class QueryCachedParams<D> : IQueryCachedParams<D>
        where D : IPrimaryKey
    {
        public readonly Lazy<IDistributedCache> Cache;
        public readonly Lazy<IQueryTyped<D>> Query;

        public QueryCachedParams(Lazy<IDistributedCache> cache, Lazy<IQueryTyped<D>> query)
        {
            Cache = cache;
            Query = query;
        }
    }

    public abstract class QueryCached<D> : IQueryCached<D>, IQueryTyped<D>
        where D : IPrimaryKey
    {
        private readonly Lazy<IDistributedCache> _cache;
        private readonly Lazy<IQueryTyped<D>> _query;

        protected QueryCached(IQueryCachedParams<D> queryParams)
        {
            var param = (QueryCachedParams<D>)queryParams;

            _cache = param.Cache;
            _query = param.Query;
        }

        public abstract Task<D?> GetAsync(object id);

        public async Task<Result<D?>> GetAsyncCached(string id)
        {
            var resultGuid = PrimaryKeyHelper.ValidateIdGetConverted<D>(id);

            if (resultGuid.IsFaulted)
            {
                return resultGuid.NewWithException<object, D?>();
            }

            var guid = resultGuid.GetValue();

            var result = await _cache.Value.GetAsync<D>(id);
            result ??= await _query.Value.GetAsync(guid);

            return new Result<D?>(result);
        }
    }
}
