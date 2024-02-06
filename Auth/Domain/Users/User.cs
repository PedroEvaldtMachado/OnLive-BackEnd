using Microsoft.AspNetCore.Identity;
using Shared.Infra;
using Shared.Infra.Enums;

namespace Domain.Users
{
    public class User : IdentityUser, IPrimaryKey
    {
        public Guid GetPrimaryKey() => Guid.Parse(Id);

        public User() : base()
        {
            DefaultAuthenticationMethod = AuthenticationMethod.None;
            UserAuthorizations = new List<UserAuthorization>();
        }

        public User(string username) : base(username)
        {
            DefaultAuthenticationMethod = AuthenticationMethod.None;
            UserAuthorizations = new List<UserAuthorization>();
        } 

        public User(string username, AuthenticationMethod defaultAuthenticationMethod, ICollection<UserAuthorization> userAuthorizations) : base(username)
        {
            DefaultAuthenticationMethod = defaultAuthenticationMethod;
            UserAuthorizations = userAuthorizations;
        }

        public AuthenticationMethod DefaultAuthenticationMethod { get; set; }
        public ICollection<UserAuthorization> UserAuthorizations { get; set; }
    }
}
