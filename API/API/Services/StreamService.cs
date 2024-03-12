
using API.Database;
using API.Models;
using MongoDB.Driver;

namespace API.Services
{
    public class StreamService : IStreamService
    {

        private readonly IMongoCollection<Streams> _streams;
        public StreamService(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _streams = database.GetCollection<Streams>(settings.StreamsCollectionName);

        }

        public Streams Create(Streams stream)
        {
           _streams.InsertOne(stream);
            return stream;
        }

        public List<Streams> Get()
        {
           return _streams.Find(stream=>true).ToList();
        }
    }
}
