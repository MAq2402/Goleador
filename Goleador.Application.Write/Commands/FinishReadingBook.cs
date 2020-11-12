using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Application.Write.Commands
{
    public class FinishReadingBook : IRequest
    {
        public FinishReadingBook(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
