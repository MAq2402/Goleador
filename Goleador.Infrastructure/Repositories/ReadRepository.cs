using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Infrastructure.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Goleador.Infrastructure.Repositories
{
    public class ReadRepository<T> : IReadRepository<T>
    {
        private readonly IMongoCollection<T> _collection;

        public ReadRepository(Settings settings)
        {
            var client = new MongoClient(settings.MongoSettings.ConnectionString);
            var database = client.GetDatabase(settings.MongoSettings.DbName);

            var collectionName = $"{typeof(T).Name}s";

            _collection = database.GetCollection<T>(collectionName);

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return (await _collection.FindAsync(new BsonDocument())).ToList();
        }

        public async Task InsertOneAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }
    }
}
