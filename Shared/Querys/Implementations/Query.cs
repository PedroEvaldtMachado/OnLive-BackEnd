using Shared.Infra;
using Shared.Infra.Helpers;

namespace Shared.Querys.Implementations
{
    public abstract class Query<D> : IQuery<D>, IQueryGuid<D>
        where D : IPrimaryKey
    {
        public async Task<D?> GetAsync(string id)
        {
            var guid = PrimaryKeyHelper.ValidateIdGetGuid(id);

            return await GetAsync(guid);
        }

        public abstract Task<D?> GetAsync(Guid id);
    }
}
