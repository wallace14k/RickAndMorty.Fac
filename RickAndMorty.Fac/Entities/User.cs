using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RickAndMorty.Fac.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get { return Guid.NewGuid(); } set { } }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public string? PassWord { get; set; }
    }
}