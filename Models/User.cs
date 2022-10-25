using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get; set;} = String.Empty;

        [BsonElement("username")]
        public string Username {get; set;} = String.Empty;

        [BsonElement("password")]
        public string Password {get; set;} = String.Empty;

        [BsonElement("userType")]
        public string UserType {get; set;} = String.Empty;
    }
}