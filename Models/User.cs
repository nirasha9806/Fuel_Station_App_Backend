using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get; set;} = String.Empty;

        [BsonElement("name")]
        public string Name {get; set;} = String.Empty;

        [BsonElement("stations")]
        public string[]? Stations {get; set;}
    }
}