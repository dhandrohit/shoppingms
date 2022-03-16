using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shopping.API.Models
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        public string id { get; set; }  
        public string name { get; set; }
        public string description { get; set; } 
        public string category { get; set; }    
        public decimal price { get; set; }  

    }
}
