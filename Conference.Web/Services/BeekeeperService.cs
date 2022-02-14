using Conference.Models;
using MongoDB.Driver;

namespace Conference.Services;

public class BeekeeperService : IBeekeeperService
{
    private readonly IMongoCollection<Beekeeper> _beekeepers;

    public BeekeeperService(IBeekeeperStoreDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase((settings.DatabaseName));
        _beekeepers = database.GetCollection<Beekeeper>(settings.BeekeepersCollectionName);
    }

    public Beekeeper Create(Beekeeper beekeeper)
    {
        _beekeepers.InsertOne(beekeeper);
        return beekeeper;
    }

    public List<Beekeeper> Get()
    {
        return _beekeepers.Find(beekeeper => true).ToList();
    }

    public Beekeeper Get(string id)
    {
        return _beekeepers.Find(beekeeper => beekeeper.Id == id).FirstOrDefault();
    }

    public void Remove(string id)
    {
        _beekeepers.DeleteOne(beekeeper => beekeeper.Id == id);
    }

    public void Update(string id, Beekeeper beekeeper)
    {
        _beekeepers.ReplaceOne(keeper => keeper.Id == id, beekeeper);
    }
}