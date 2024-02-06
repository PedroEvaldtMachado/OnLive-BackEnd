using Shared.Domain.Basic;
using Shared.Infra.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Users
{
    [Table("UserAuthorization")]
    public class UserAuthorization : PrimaryKey
    {
        public string? Authorization { get; set; }
        public AuthenticationMethod Method { get; set; }
        public DateTimeOffset? LastLogin { get; set; }
        public DateTimeOffset? LoginExpiration { get; set; }
    }
}
