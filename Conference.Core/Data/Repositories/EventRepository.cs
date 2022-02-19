using System.Linq.Expressions;
using Conference.Contracts;
using Conference.Contracts.DTO;
using Conference.Contracts.Entities;
using Conference.Contracts.Repositories;
using MongoDB.Driver;

namespace Conference.Core.Data.Repositories;

public class EventRepository : IEventRepository
{
    
        private readonly IMongoCollection<Event> _events;

        public EventRepository(IMongoDatabase database)
        {
            _events = database.GetCollection<Event>(MongoCollectionNames.Events);
        }

        public async Task<Event> GetEventByIdAsync(string eventId)
        {
            return await GetSingleAsync(x => x.Id == eventId);
        }

        public async Task CreateEventAsync(CreateOrUpdateEventDto model)
        {
            Event ev = new Event
            {
                Title = model.Title,
                Time = model.Time,
                SpeakerName = model.SpeakerName,
                SpeakerLocation = model.SpeakerLocation
            };

            await AddAsync(ev);
        }

        public async Task<Event> UpdateEventAsync(string id, CreateOrUpdateEventDto model)
        {
            Event ev = new Event
            {
                Id = id,
                Title = model.Title,
                Time = model.Time,
                SpeakerName = model.SpeakerName,
                SpeakerLocation = model.SpeakerLocation
            };

            return await UpdateAsync(ev);
        }

        public async Task DeleteEventAsync(string id)
        {
            await DeleteAsync(x => x.Id == id);
        }

        #region IRepository implementation

        public async Task AddAsync(Event obj)
        {
            await _events.InsertOneAsync(obj);
        }

        public async Task DeleteAsync(Expression<Func<Event, bool>> predicate)
        {
            _ = await _events.DeleteOneAsync(predicate);
        }

        public IQueryable<Event> GetAll()
        {
            return _events.AsQueryable();
        }

        public async Task<Event> GetSingleAsync(Expression<Func<Event, bool>> predicate)
        {
            var filter = Builders<Event>.Filter.Where(predicate);
            return (await _events.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<Event> UpdateAsync(Event obj)
        {
            var filter = Builders<Event>.Filter.Where(x => x.Id == obj.Id);
            
            var updateDefBuilder = Builders<Event>.Update;
            var updateDef = updateDefBuilder.Combine(new UpdateDefinition<Event>[]
            {
                updateDefBuilder.Set(x => x.Title, obj.Title),
                updateDefBuilder.Set(x => x.Time, obj.Time),
                updateDefBuilder.Set(x => x.SpeakerName, obj.SpeakerName),
                updateDefBuilder.Set(x => x.SpeakerLocation, obj.SpeakerLocation)
            });
            await _events.FindOneAndUpdateAsync(filter, updateDef);

            return await _events.FindOneAndReplaceAsync(x => x.Id == obj.Id, obj);
        }
        #endregion
}