namespace Shared.Dtos.Users
{
    public class NewUserDto
    {
        public NewUserDto()
        {
            Email = string.Empty;
        }

        public NewUserDto(string? username, string email)
        {
            Username = username;
            Email = email;
        }

        public string? Username { get; set; }
        public string Email { get; set; }
    }
}
