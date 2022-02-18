using Conference.Contracts.DTO;
using Conference.Contracts.Entities;

namespace Conference.Contracts.Repositories;

public interface IBeekeeperRepository : IRepository<Beekeeper>
{
    Task<Beekeeper> GetBeekeeperByIdAsync(string beekeeperId);

    Task CreateBeekeeperAsync(CreateOrUpdateBeekeeperDto model);

    Task<Beekeeper> UpdateBeekeeperAsync(string id, CreateOrUpdateBeekeeperDto model);

    Task DeleteBeekeeperAsync(string id);
}