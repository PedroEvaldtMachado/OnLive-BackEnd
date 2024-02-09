using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Shared.Infra;

namespace Domain
{
    [BsonIgnoreExtraElements]
    public abstract class Base<T> : IPrimaryKey
    {
        [BsonId, BsonRepresentation(BsonType.String)]
        public virtual T Id { get; set; } = default!;

        public virtual object GetPrimaryKey() => Id!;
    }
}
