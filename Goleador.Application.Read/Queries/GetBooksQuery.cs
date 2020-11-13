using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Application.Read.Models;
using MediatR;

namespace Goleador.Application.Read.Queries
{
    public class GetBooksQuery : IRequest<IEnumerable<Book>>
    {
        public GetBooksQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
