using Conference.Contracts;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Conference.Core.Data;

public class MongoContext
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;

    public MongoContext(IOptions<DatabaseSettings> dbSettings)
    {
        var settings = dbSettings.Value;
        _client = new MongoClient(settings.ConnectionString);
        _database = _client.GetDatabase(settings.DatabaseName);
    }

    public IMongoClient Client => _client;
    public IMongoDatabase Database => _database;
}