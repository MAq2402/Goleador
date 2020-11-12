using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Goleador.Application.Messages.Messages;
using Goleador.Application.Write.Commands;
using Goleador.Domain.Base;
using Goleador.Domain.Book;
using Goleador.Infrastructure.Messages;
using MediatR;

namespace Goleador.Application.Write.CommandHandlers
{
    public class AddBookToFutureReadListHandler : IRequestHandler<AddBookToFutureReadList>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMessageService _messageService;

        public AddBookToFutureReadListHandler(IRepository<Book> bookRepository, IMessageService messageService)
        {
            _bookRepository = bookRepository;
            _messageService = messageService;
        }

        public async Task<Unit> Handle(AddBookToFutureReadList request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Title, string.Join(", ", request.Authors), 
                request.Thumbnail, request.PublishedYear, request.ExternalId, request.UserId);

            await _bookRepository.AddAsync(book);

            await _bookRepository.SaveChangesAsync();

            await _messageService.PublishAsync(new BookAddedToFutureReadList(book.Id, book.Title, book.Authors, 
                request.Thumbnail, request.PublishedYear, request.ExternalId, "To read", book.Created));

            return Unit.Value;
        }
    }
}