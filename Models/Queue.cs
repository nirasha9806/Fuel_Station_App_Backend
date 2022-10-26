using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class Queue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; } = String.Empty;

        // [BsonElement("stationId")]
        // public string stationId { get; set; } = String.Empty;

        [BsonElement("username")]
        public string Username { get; set; } = String.Empty;

        [BsonElement("vehicleType")]
        public string VehicleType { get; set; } = String.Empty;

        [BsonElement("arrivalTime")]
        public string ArrivalTime { get; set; } = String.Empty;


        [BsonElement("departTime")]
        public string DepartTime { get; set; } = String.Empty;

    }
}