using Shared.Domain.Basic;
using Shared.Infra.Enums;

namespace Domain.Users
{
    public class User : PrimaryKey
    {
        public User(string email)
        {
            Email = email;
            DefaultAuthenticationMethod = AuthenticationMethod.None;
            UserAuthorizations = new List<UserAuthorization>();
        }

        public User(string? username, string email) {
            Username = username;
            Email = email;
            DefaultAuthenticationMethod = AuthenticationMethod.None;
            UserAuthorizations = new List<UserAuthorization>();
        }

        public User(string? username, string email, AuthenticationMethod defaultAuthenticationMethod, ICollection<UserAuthorization> userAuthorizations)
        {
            Username = username;
            Email = email;
            DefaultAuthenticationMethod = defaultAuthenticationMethod;
            UserAuthorizations = userAuthorizations;
        }

        public string? Username { get; set; }
        public string Email { get; set; }
        public AuthenticationMethod DefaultAuthenticationMethod { get; set; }
        public ICollection<UserAuthorization> UserAuthorizations { get; set; }
    }
}
