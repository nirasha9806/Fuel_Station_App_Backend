using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class Queue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; } = String.Empty;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string stationId { get; set; } = String.Empty;

        [BsonElement("username")]
        public string Users { get; set; } = String.Empty;

        [BsonElement("vehicleType")]
        public string VehicleType { get; set; } = String.Empty;

        [BsonElement("arrivalTime")]
        public TimeOnly arrivalTime { get; set; }

        [BsonElement("departTime")]
        public TimeOnly departTime { get; set; }
    }
}