using Conference.Contracts.DTO;
using Conference.Contracts.Entities;

namespace Conference.Contracts.Repositories;

public interface IEventRepository : IRepository<Event>
{
    Task<Event> GetBeekeeperByIdAsync(string eventId);

    Task CreateBeekeeperAsync(CreateOrUpdateEventDto model);

    Task<Event> UpdateBeekeeperAsync(string id, CreateOrUpdateEventDto model);

    Task DeleteBeekeeperAsync(string id);
}