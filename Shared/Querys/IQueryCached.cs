#pragma warning disable S2326 // Unused type parameters should be removed
using LanguageExt.Common;

namespace Shared.Querys
{
    public interface IQueryCached<D>
    {
        public Task<Result<D?>> GetAsyncCached(string id);
    }

    public interface IQueryCachedParams<D>
    {
    }
}
