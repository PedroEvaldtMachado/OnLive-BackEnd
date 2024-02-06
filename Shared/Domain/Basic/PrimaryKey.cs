using Shared.Infra;
using System.ComponentModel.DataAnnotations;

namespace Shared.Domain.Basic
{
    public abstract class PrimaryKey : IPrimaryKey
    {
        [Key]
        public Guid Id { get; set; }

        public Guid GetPrimaryKey() => Id;
    }
}
