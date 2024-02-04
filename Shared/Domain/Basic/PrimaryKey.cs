using Shared.Infra;

namespace Shared.Domain.Basic
{
    public abstract class PrimaryKey : IPrimaryKey
    {
        public Guid Id { get; set; }

        public Guid GetPrimaryKey() => Id;
    }
}
