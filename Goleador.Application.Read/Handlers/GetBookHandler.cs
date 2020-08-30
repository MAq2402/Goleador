using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Goleador.Application.Read.Models;
using Goleador.Application.Read.Queries;
using Goleador.Infrastructure.Repositories;
using MediatR;

namespace Goleador.Application.Read.Handlers
{
    public class GetBookHandler : IRequestHandler<GetBookQuery, Book>
    {
        private readonly IReadRepository<Book> _bookRepository;

        public GetBookHandler(IReadRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetAsync(request.Id);
        }
    }
}
