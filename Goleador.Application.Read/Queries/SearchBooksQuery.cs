using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Application.Read.Models;
using MediatR;

namespace Goleador.Application.Read.Queries
{
    public class SearchBooksQuery : IRequest<SearchedBookCollection>
    {
        public SearchBooksQuery(string query)
        {
            Query = query;
        }

        public string Query { get; }
    }
}