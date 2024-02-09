using Shared.Infra;

namespace Shared.Dtos.Basic
{
    public abstract class PrimaryKeyDto<P> : IPrimaryKey
    {
        public P Id { get; set; }

        public virtual object GetPrimaryKey() => Id;
    }
}
