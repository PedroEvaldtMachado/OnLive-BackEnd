using Shared.Dtos.Users;

namespace Services.Users
{
    public interface IUserService
    {
        public UserDto CreateFakeUser(string? username, string email);
    }
}
