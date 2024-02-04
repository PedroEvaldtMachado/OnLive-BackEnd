using Querys.Users;
using Shared.Dtos.Users;
using Shared.Querys.Implementations;
using Shared.Querys;

namespace Querys.Implementations.Users
{
    internal class UserQuery : QueryCached<UserDto>, IUserQuery
    {
        public UserQuery(IQueryCachedParams<UserDto> queryParams) : base (queryParams) { }

        public Task<UserDto?> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
