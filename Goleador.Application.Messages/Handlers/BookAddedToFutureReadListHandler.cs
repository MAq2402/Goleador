using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Application.Messages.Handlers;
using Goleador.Application.Messages.Messages;
using Goleador.Application.Read.Models;
using Goleador.Infrastructure.Repositories;

namespace Goleador.Application.Read.MessageHandlers
{
    public class BookAddedToFutureReadListHandler : IMessageHandler<BookAddedToFutureReadList>
    {
        private readonly IReadRepository<Book> _bookRepository;

        public BookAddedToFutureReadListHandler(IReadRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task HandleAsync(BookAddedToFutureReadList message)
        {
            var book = new Book()
            {
                Id = message.Id,
                Title = message.Title,
                Authors = message.Authors,
                Thumbnail = message.Thumbnail,
                ExternalId = message.ExternalId,
                PublishedYear = message.PublishedYear,
                Status = message.Status,
                Created = message.Created
            };

            await _bookRepository.InsertOneAsync(book);
        }
    }
}