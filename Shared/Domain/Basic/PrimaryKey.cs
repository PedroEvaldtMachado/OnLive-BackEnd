using Shared.Infra;
using System.ComponentModel.DataAnnotations;

namespace Shared.Domain.Basic
{
    public abstract class PrimaryKey<T> : IPrimaryKey
    {
        [Key]
        public virtual T Id { get; set; } = default!;

        public object GetPrimaryKey() => Id!;
    }
}
