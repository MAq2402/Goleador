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
    public class AddBookToFutureReadListHandler : IRequestHandler<AddBookToFutureReadListCommand>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMessageService _messageService;

        public AddBookToFutureReadListHandler(IRepository<Book> bookRepository, IMessageService messageService)
        {
            _bookRepository = bookRepository;
            _messageService = messageService;
        }

        public async Task<Unit> Handle(AddBookToFutureReadListCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Name, request.Author);

            await _bookRepository.AddAsync(book);

            await _bookRepository.SaveChangesAsync();

            await _messageService.PublishAsync(new BookAddedToFutureReadList(book.Id, book.Name, book.Author, "To read",
                book.Created));

            return Unit.Value;
        }
    }
}