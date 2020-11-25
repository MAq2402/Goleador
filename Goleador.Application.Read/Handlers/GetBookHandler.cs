using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Goleador.Application.Read.Models;
using Goleador.Application.Read.Queries;
using Goleador.Application.Read.Repositories;
using Goleador.Application.Shared.Exceptions;
using Goleador.Infrastructure.Repositories;
using MediatR;

namespace Goleador.Application.Read.Handlers
{
    public class GetBookHandler : IRequestHandler<GetBookQuery, Book>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.BookWithPomodorosAsync(request.Id) ?? 
                throw new NotFoundException($"Book with id: {request.Id} does not exist.");
        }
    }
}
