using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Notifications.Models;

[BsonIgnoreExtraElements]
public class Participant
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public  string Id { get; set; } = String.Empty;
    
    [BsonElement("name")]
    [Required(ErrorMessage = "Анонимным участникам у нас не рады")]
    public string Name { get; set; } = String.Empty;
    
    [BsonElement("city")]
    public string? City { get; set; } 
    
    [BsonElement("email")]
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage="Это не email")]
    public string Email { get; set; } = String.Empty;
    
    [BsonElement("phone")]
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage="Это не номер телефона")]
    public string Phone { get; set; } = String.Empty;
    
    [BsonElement("expected")]
    public bool Expected { get; set; }
}