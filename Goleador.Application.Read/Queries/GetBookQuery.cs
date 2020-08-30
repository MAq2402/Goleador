using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Application.Read.Models;
using MediatR;

namespace Goleador.Application.Read.Queries
{
    public class GetBookQuery : IRequest<Book>
    {
        public GetBookQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
