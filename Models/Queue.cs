using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class Queue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get; set;} = String.Empty;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string stationId {get; set;} = String.Empty;

        [BsonElement("fuelType")]
        public string fuelType {get; set;} = String.Empty;

        [BsonElement("users")]
        public object[]? Users {get; set;} 
    }
}