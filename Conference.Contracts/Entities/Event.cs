using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Conference.Contracts.Entities;

[BsonIgnoreExtraElements]
public class Event
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Title { get; set; }
    public string Time { get; set; }
    public string SpeakerName { get; set; }
    public string SpeakerLocation { get; set; }
}