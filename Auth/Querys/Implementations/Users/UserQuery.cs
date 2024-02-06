using Querys.Users;
using Shared.Dtos.Users;
using Shared.Querys.Implementations;
using Shared.Querys;
using LanguageExt.Common;

namespace Querys.Implementations.Users
{
    internal class UserQuery : QueryCached<UserDto>, IUserQuery
    {
        public UserQuery(IQueryCachedParams<UserDto> queryParams) : base (queryParams) { }

        public async Task<Result<UserDto?>> GetAsync(string id)
        {
            return await Task.Run(() => { return new Result<UserDto?>(new NotImplementedException("Método não implementado")); });
        }
    }
}
