using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class FuelStation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get; set;} = String.Empty;

        [BsonElement("name")]
        public string Name {get; set;} = String.Empty;

        [BsonElement("city")]
        public string City {get; set;} = String.Empty;

        [BsonElement("currentFuelLength")]
        public object? CurrentFuelLength {get; set;}

        [BsonElement("fuelStatus")]
        public object? FuelStatus {get; set;}

        [BsonElement("waitingTime")]
        public object? WaitingTime {get; set;}
    }
}