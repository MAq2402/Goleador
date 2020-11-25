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
        protected IMongoCollection<T> Collection { get; }

        public ReadRepository(Settings settings)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
            var client = new MongoClient(settings.MongoSettings.ConnectionString);
            var database = client.GetDatabase(settings.MongoSettings.DbName);

            var collectionName = $"{typeof(T).Name}s";

            Collection = database.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return (await Collection.FindAsync(new BsonDocument())).ToList();
        }

        public async Task InsertOneAsync(T entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public async Task<T> GetAsync(Guid id)
        {
            return (await Collection.FindAsync(x => x.Id == id)).FirstOrDefault();
        }

        public async Task UpdateAsync(Guid id, Dictionary<string, object> fieldValuePairs)
        {
            var updates = new List<UpdateDefinition<T>>();
            foreach (var (key, value) in fieldValuePairs)
            {
                updates.Add(Builders<T>.Update.Set(key, value));
            }

            var combinedUpdate = Builders<T>.Update.Combine(updates);

            await Collection.FindOneAndUpdateAsync(x => x.Id == id, combinedUpdate);
        }
    }
}