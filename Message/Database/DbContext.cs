using Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shared.Infra;

namespace Database
{
    public class DbContext<T> : IDbContext<T>
        where T : IPrimaryKey
    {
        private readonly MongoClient _mongoClient;

        public DbContext(IOptions<DbConnection> settings) {
            _mongoClient = new MongoClient(settings.Value.ConnectionDatabase.ConnectionStrings);
        }

        public IMongoDatabase GetDatabase()
        {
            return _mongoClient.GetDatabase(typeof(T).Name);
        }
    }
}
