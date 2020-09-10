﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Application.Read.Models;
using Goleador.Infrastructure.Repositories;
using Goleador.Infrastructure.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Goleador.Application.Read.Repositories
{
    public class BookRepository : ReadRepository<Book>, IBookRepository
    {
        public BookRepository(Settings settings) : base(settings)
        {
        }

        public async Task<IEnumerable<Book>> BooksWithPomodorosAsync()
        {
            var books = await _collection.Aggregate()
                .Lookup("Pomodoros", "_id", "PomodorableId", "Pomodoros")
                .ToListAsync();

            return await Task.FromResult(BsonSerializer.Deserialize<IEnumerable<Book>>(books.ToJson()));
        }

        public async Task<Book> BookWithPomodorosAsync(Guid requestId)
        {
            var book =  await _collection.Aggregate()
                .Match(b => b.Id == requestId)
                .Lookup("Pomodoros", "_id", "PomodorableId", "Pomodoros")
                .FirstOrDefaultAsync();

            return BsonSerializer.Deserialize<Book>(book);
        }
    }
}