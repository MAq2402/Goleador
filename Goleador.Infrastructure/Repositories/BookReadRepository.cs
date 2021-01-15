using Goleador.Application.Read.Models;
using Goleador.Application.Read.Repositories;
using Goleador.Infrastructure.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Infrastructure.Repositories
{
    public class BookReadRepository : MongoReadRepository<Book>, IBookRepository
    {
        public BookReadRepository(Settings settings) : base(settings)
        {
        }

        public async Task<IEnumerable<Book>> BooksWithPomodorosAsync(string userId, string status = null)
        {
            var books = await Collection.Aggregate()
                .Match(b => b.UserId == userId)
                .Match(b => !string.IsNullOrEmpty(status) && b.Status == status)
                .Lookup("Pomodoros", "_id", "PomodorableId", "Pomodoros")
                .ToListAsync();

            return await Task.FromResult(BsonSerializer.Deserialize<IEnumerable<Book>>(books.ToJson()));
        }

        public async Task<Book> BookWithPomodorosAsync(Guid requestId)
        {
            var book = await Collection.Aggregate()
                .Match(b => b.Id == requestId)
                .Lookup("Pomodoros", "_id", "PomodorableId", "Pomodoros")
                .FirstOrDefaultAsync();

            return BsonSerializer.Deserialize<Book>(book);
        }

        public async Task<string> GetUserId(Guid bookId)
        {
            return (await Collection.Aggregate().Match(b => b.Id == bookId).FirstOrDefaultAsync()).UserId;
        }
    }
}
