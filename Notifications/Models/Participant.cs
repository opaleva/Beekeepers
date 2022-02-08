using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Notifications.Models;

public class Participant
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [Required(ErrorMessage = "Анонимным участникам у нас не рады")]
    public string Name { get; set; }
    public string? City { get; set; }
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage="Это не email")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage="Это не номер телефона")]
    public string Phone { get; set; }
    public bool? Expected { get; set; }
}