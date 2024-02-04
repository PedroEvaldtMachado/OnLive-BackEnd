#pragma warning disable S2326 // Unused type parameters should be removed

namespace Shared.Querys
{
    public interface IQueryCached<D>
    {
        public Task<D?> GetAsyncCached(string id);
    }

    public interface IQueryCachedParams<D>
    {
    }
}
