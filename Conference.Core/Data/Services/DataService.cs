using Conference.Contracts.Repositories;
using Conference.Contracts.Services;
using Conference.Core.Data.Repositories;

namespace Conference.Core.Data.Services;

public class DataService : IDataService
{
    private readonly MongoContext _mongoContext;

    public DataService(MongoContext mongoContext)
    {
        _mongoContext = mongoContext;
    }

    public IBeekeeperRepository Beekeepers => new BeekeeperRepository(_mongoContext.Database);
    public IEventRepository Events => new EventRepository(_mongoContext.Database);
}