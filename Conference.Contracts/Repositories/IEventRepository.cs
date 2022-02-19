using Conference.Contracts.DTO;
using Conference.Contracts.Entities;

namespace Conference.Contracts.Repositories;

public interface IEventRepository : IRepository<Event>
{
    Task<Event> GetEventByIdAsync(string eventId);

    Task CreateEventAsync(CreateOrUpdateEventDto model);

    Task<Event> UpdateEventAsync(string id, CreateOrUpdateEventDto model);

    Task DeleteEventAsync(string id);
}