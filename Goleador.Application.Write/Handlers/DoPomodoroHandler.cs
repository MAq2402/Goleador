using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Goleador.Application.Shared.Exceptions;
using Goleador.Application.Write.Commands;
using Goleador.Domain.Base;
using Goleador.Domain.Book;
using Goleador.Infrastructure.Messages;
using MediatR;

namespace Goleador.Application.Write.Handlers
{
    public class DoPomodoroHandler : IRequestHandler<DoPomodoro>
    {
        private readonly IRepository<Book> _bookRepository;

        public DoPomodoroHandler(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(DoPomodoro request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(request.PomodorableId);

            if(book == null)
            {
                throw new NotFoundException($"Book with id: {request.PomodorableId} does not exist.");
            }

            book.DoPomodoro();

            await _bookRepository.SaveChangesAsync(book);

            return Unit.Value;
        }
    }
}
