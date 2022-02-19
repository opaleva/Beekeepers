using System.Linq.Expressions;
using Conference.Contracts;
using Conference.Contracts.DTO;
using Conference.Contracts.Entities;
using Conference.Contracts.Repositories;
using MongoDB.Driver;

namespace Conference.Core.Data.Repositories;

public class BeekeeperRepository : IBeekeeperRepository
{
    
        private readonly IMongoCollection<Beekeeper> _beekeepers;

        public BeekeeperRepository(IMongoDatabase database)
        {
            _beekeepers = database.GetCollection<Beekeeper>(MongoCollectionNames.Beekeepers);
        }

        public async Task<Beekeeper> GetBeekeeperByIdAsync(string beekeeperId)
        {
            return await GetSingleAsync(x => x.Id == beekeeperId);
        }

        public async Task CreateBeekeeperAsync(CreateOrUpdateBeekeeperDto model)
        {
            Beekeeper beekeeper = new Beekeeper
            {
                Name = model.Name,
                City = model.City,
                Email = model.Email,
                Phone = model.Phone,
                Expected = model.Expected
            };

            await AddAsync(beekeeper);
        }

        public async Task<Beekeeper> UpdateBeekeeperAsync(string id, CreateOrUpdateBeekeeperDto model)
        {
            Beekeeper beekeeper = new Beekeeper
            {
                Id = id,
                Name = model.Name,
                City = model.City,
                Email = model.Email,
                Phone = model.Phone,
                Expected = model.Expected
            };

            return await UpdateAsync(beekeeper);
        }

        public async Task DeleteBeekeeperAsync(string id)
        {
            await DeleteAsync(x => x.Id == id);
        }

        #region IRepository implementation

        public async Task AddAsync(Beekeeper obj)
        {
            await _beekeepers.InsertOneAsync(obj);
        }

        public async Task DeleteAsync(Expression<Func<Beekeeper, bool>> predicate)
        {
            _ = await _beekeepers.DeleteOneAsync(predicate);
        }

        public IQueryable<Beekeeper> GetAll()
        {
            return _beekeepers.AsQueryable();
        }

        public async Task<Beekeeper> GetSingleAsync(Expression<Func<Beekeeper, bool>> predicate)
        {
            var filter = Builders<Beekeeper>.Filter.Where(predicate);
            return (await _beekeepers.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<Beekeeper> UpdateAsync(Beekeeper obj)
        {
            var filter = Builders<Beekeeper>.Filter.Where(x => x.Id == obj.Id);
            
            var updateDefBuilder = Builders<Beekeeper>.Update;
            var updateDef = updateDefBuilder.Combine(new UpdateDefinition<Beekeeper>[]
            {
                updateDefBuilder.Set(x => x.Name, obj.Name),
                updateDefBuilder.Set(x => x.City, obj.City),
                updateDefBuilder.Set(x => x.Email, obj.Email),
                updateDefBuilder.Set(x => x.Phone, obj.Phone),
                updateDefBuilder.Set(x => x.Expected, obj.Expected)
            });
            await _beekeepers.FindOneAndUpdateAsync(filter, updateDef);

            return await _beekeepers.FindOneAndReplaceAsync(x => x.Id == obj.Id, obj);
        }
        #endregion
}