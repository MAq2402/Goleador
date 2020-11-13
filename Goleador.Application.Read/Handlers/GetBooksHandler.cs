using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Goleador.Application.Read.Models;
using Goleador.Application.Read.Queries;
using Goleador.Application.Read.Repositories;
using Goleador.Infrastructure.Repositories;
using MediatR;

namespace Goleador.Application.Read.Handlers
{
    public class GetBooksHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.BooksWithPomodorosAsync(request.UserId);
        }
    }
}
