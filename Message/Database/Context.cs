using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shared.Infra;

namespace Database
{
    internal class Context
    {
        private readonly IMongoDatabase _database;

        public Context(IOptions<Connection> settings) {
            _database = new MongoClient(settings.Value.ConnectionStrings).GetDatabase(settings.Value.DatabaseName);
        }
    }
}
