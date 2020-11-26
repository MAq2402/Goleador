using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Goleador.Application.Read.Models;
using Goleador.Application.Read.Queries;
using Goleador.Application.Read.Services;
using MediatR;

namespace Goleador.Application.Read.Handlers
{
    public class SearchBooksHandler : IRequestHandler<SearchBooksQuery, SearchedBookCollection>
    {
        private readonly IBookSearchService _searchService;

        public SearchBooksHandler(IBookSearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<SearchedBookCollection> Handle(SearchBooksQuery request, CancellationToken cancellationToken)
        {
            return await _searchService.SearchAsync(request.Query);
        }
    }
}
