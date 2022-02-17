using Conference.Contracts.Entities;

namespace Conference.Contracts.DTO;

public class BeekeeperResponseModel : BaseResponseModel
{
    public Beekeeper Response { get; set; }
}