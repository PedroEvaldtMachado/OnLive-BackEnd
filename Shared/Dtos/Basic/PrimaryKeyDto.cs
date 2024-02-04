using Shared.Infra;

namespace Shared.Dtos.Basic
{
    public class PrimaryKeyDto : IPrimaryKey
    {
        public Guid Id { get; set; }

        public Guid GetPrimaryKey() => Id;
    }
}
