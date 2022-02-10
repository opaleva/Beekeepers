using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Notifications.Models;

public class Participant
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public  string Id { get; set; } = String.Empty;
    [Required(ErrorMessage = "Анонимным участникам у нас не рады")]
    public string Name { get; set; } = String.Empty;
    public string? City { get; set; } 
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage="Это не email")]
    public string Email { get; set; } = String.Empty;
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage="Это не номер телефона")]
    public string Phone { get; set; } = String.Empty;
    public bool Expected { get; set; }
}