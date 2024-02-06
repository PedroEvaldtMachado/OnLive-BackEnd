using LanguageExt.Common;
using Shared.Dtos.Users;

namespace Services.Users
{
    public interface IUserService
    {
        public Result<UserDto> CreateFakeUser(string? username, string email);
    }
}
