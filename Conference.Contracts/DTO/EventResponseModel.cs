using Conference.Contracts.Entities;

namespace Conference.Contracts.DTO;

public class EventResponseModel : BaseResponseModel
{
    public Event Response { get; set; }
}