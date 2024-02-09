#pragma warning disable S3246 // Generic type parameters should be co/contravariant when possible

namespace Shared.Infra
{
    public interface IBuilder<T>
    {
        T Build(string context);
    }
}
