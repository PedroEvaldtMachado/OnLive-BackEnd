using LanguageExt.Common;
using Shared.Infra;
using Shared.Infra.Extensions;
using Shared.Infra.Helpers;

namespace Shared.Querys.Implementations
{
    public abstract class Query<D> : IQuery<D>, IQueryTyped<D>
        where D : IPrimaryKey
    {
        public async Task<Result<D?>> GetAsync(string id)
        {
            var resultGuid = PrimaryKeyHelper.ValidateIdGetConverted<D>(id);

            if (resultGuid.IsFaulted)
            {
                return resultGuid.NewWithException<object, D?>();
            }

            var guid = resultGuid.GetValue();

            return await GetAsync(guid);
        }

        public abstract Task<D?> GetAsync(object id);
    }
}
