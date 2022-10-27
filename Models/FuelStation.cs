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

        [BsonElement("fuelDetails")]
        public List<object>? fuelDetails {get; set;}
    }
}