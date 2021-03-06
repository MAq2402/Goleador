﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Application.Messages.Handlers;
using Goleador.Application.Read.Models;
using Goleador.Application.Read.Repositories;
using Goleador.Domain.Book.Events;

namespace Goleador.Application.Read.MessageHandlers
{
    public class BookAddedToFutureReadListHandler : IMessageHandler<BookCreated>
    {
        private readonly IRepository<Book> _bookRepository;

        public BookAddedToFutureReadListHandler(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task HandleAsync(BookCreated message)
        {
            var book = new Book()
            {
                Id = message.AggregateId,
                Title = message.Title,
                Authors = message.Authors,
                Thumbnail = message.Thumbnail,
                ExternalId = message.ExternalId,
                PublishedYear = message.PublishedYear,
                Status = message.Status,
                Created = message.Created,
                UserId = message.UserId
            };

            await _bookRepository.InsertOneAsync(book);
        }
    }
}