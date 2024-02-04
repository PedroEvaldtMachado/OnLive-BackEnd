using Shared.Domain.Basic;

namespace Domain.Users
{
    public class UserAuthorization : PrimaryKey
    {
        public string? Authorization { get; set; }
        public DateTimeOffset? LastLogin { get; set; }
        public DateTimeOffset? LoginExpiration { get; set; }
    }
}
