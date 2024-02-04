using Shared.Dtos.Users;
using Shared.Querys;

namespace Querys.Users
{
    public interface IUserQuery : IQuery<UserDto>, IQueryCached<UserDto>
    {
    }
}
