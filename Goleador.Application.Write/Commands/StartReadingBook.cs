using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Goleador.Application.Write.Commands
{
    public class StartReadingBook : IRequest
    {
        public StartReadingBook(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
