using Conference.Contracts.Repositories;

namespace Conference.Contracts.Services;

public interface IDataService
{
    public IBeekeeperRepository Beekeepers { get; }
    
    public IEventRepository Events { get; }
}