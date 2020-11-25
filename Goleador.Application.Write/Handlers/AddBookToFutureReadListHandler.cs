using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Goleador.Application.Write.Commands;
using Goleador.Domain.Base;
using Goleador.Domain.Book;
using MediatR;

namespace Goleador.Application.Write.CommandHandlers
{
    public class AddBookToFutureReadListHandler : IRequestHandler<AddBookToFutureReadList>
    {
        private readonly IRepository<Book> _bookRepository;

        public AddBookToFutureReadListHandler(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(AddBookToFutureReadList request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Title, string.Join(", ", request.Authors), 
                request.Thumbnail, request.PublishedYear, request.ExternalId, request.UserId);

            await _bookRepository.AddAsync(book);

            await _bookRepository.SaveChangesAsync(book);

            return Unit.Value;
        }
    }
}