using LanguageExt.Common;
using Shared.Infra;
using Shared.Infra.Extensions;
using Shared.Infra.Helpers;

namespace Shared.Querys.Implementations
{
    public abstract class Query<D> : IQuery<D>, IQueryGuid<D>
        where D : IPrimaryKey
    {
        public async Task<Result<D?>> GetAsync(string id)
        {
            var resultGuid = PrimaryKeyHelper.ValidateIdGetGuid(id);

            if (resultGuid.IsFaulted)
            {
                return resultGuid.NewWithException<Guid, D?>();
            }

            var guid = resultGuid.GetValue();

            return await GetAsync(guid);
        }

        public abstract Task<D?> GetAsync(Guid id);
    }
}
