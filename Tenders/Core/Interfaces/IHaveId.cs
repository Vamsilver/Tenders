using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tenders.Core.Interfaces;

public interface IHaveId
{
    [BsonId]
    public ObjectId Id { get; set; }
}