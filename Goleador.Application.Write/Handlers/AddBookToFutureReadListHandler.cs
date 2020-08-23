using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Goleador.Application.Write.Commands;
using Goleador.Domain.Base;
using Goleador.Domain.Book;
using MediatR;

namespace Goleador.Application.Write.Handlers
{
    public class AddBookToFutureReadListHandler : IRequestHandler<AddBookToFutureReadListCommand>
    {
        private IRepository<Book> _bookRepository;

        public AddBookToFutureReadListHandler(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(AddBookToFutureReadListCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.AddAsync(new Book(request.Name, request.Author));

            await _bookRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
