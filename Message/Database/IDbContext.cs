#pragma warning disable S2326 // Unused type parameters should be removed
using MongoDB.Driver;
using Shared.Infra;

namespace Database
{
    public interface IDbContext<T>
        where T : IPrimaryKey
    {
        IMongoDatabase GetDatabase();
    }
}
