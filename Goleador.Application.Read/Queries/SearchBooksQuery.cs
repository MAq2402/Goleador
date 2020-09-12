using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Infrastructure.BookSearch.Models;
using MediatR;

namespace Goleador.Application.Read.Queries
{
    public class SearchBooksQuery : IRequest<BookResponse>
    {
        public SearchBooksQuery(string query)
        {
            Query = query;
        }

        public string Query { get; }
    }
}