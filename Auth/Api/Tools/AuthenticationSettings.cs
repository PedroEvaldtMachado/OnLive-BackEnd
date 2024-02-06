using Shared.Infra.Enums;

namespace Api.Tools
{
    public class AuthenticationSettings
    {
        public ICollection<AuthenticationInfomations> Authentications { get; set; }

        public AuthenticationSettings()
        {
            Authentications = new List<AuthenticationInfomations>();
        }
    }

    public class AuthenticationInfomations
    {
        public AuthenticationMethod Method { get; set; }
        public string? Id { get; set; }
        public string? Key { get; set; }
    }
}
