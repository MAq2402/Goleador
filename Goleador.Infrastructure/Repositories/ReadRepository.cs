using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Infrastructure.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
#pragma warning disable 618

namespace Goleador.Infrastructure.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : ReadModel
    {
        protected readonly IMongoCollection<T> _collection;

        public ReadRepository(Settings settings)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
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

        public async Task<T> GetAsync(Guid id)
        {
            return (await _collection.FindAsync(x => x.Id == id)).FirstOrDefault();
        }

        public async Task UpdateAsync(Guid id, Dictionary<string, string> fieldValuePairs)
        {
            var updateBuilder = Builders<T>.Update;
            UpdateDefinition<T> update = null;
            foreach (var (key, value) in fieldValuePairs)
            {
                update = updateBuilder.Set(key, value);
            }

            await _collection.FindOneAndUpdateAsync(x => x.Id == id, update);
        }
    }
}