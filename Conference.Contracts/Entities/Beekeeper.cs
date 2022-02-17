using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Conference.Contracts.Entities;

[BsonIgnoreExtraElements]
public class Beekeeper
{
    public Beekeeper()
    {
        this.AddedOn = DateTime.UtcNow;
    }
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public  string Id { get; set; } 
    public string Name { get; set; } 
    public string City { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool Expected { get; set; }
    public DateTime AddedOn { get; set; }
}