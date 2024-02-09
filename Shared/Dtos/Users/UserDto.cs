using Shared.Dtos.Basic;

namespace Shared.Dtos.Users
{
    public class UserDto : PrimaryKeyDto<Guid>
    {
        public UserDto()
        {
            Email = string.Empty;
        }

        public UserDto(string email)
        {
            Email = email;
        }

        public UserDto(string? username, string email)
        {
            Username = username;
            Email = email;
        }

        public string? Username { get; set; }
        public string Email { get; set; }
    }
}
