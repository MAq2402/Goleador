using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Goleador.Application.Messages.Messages;
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
        private readonly IMessageService _messageService;

        public DoPomodoroHandler(IRepository<Book> bookRepository, IMessageService messageService)
        {
            _bookRepository = bookRepository;
            _messageService = messageService;
        }

        public async Task<Unit> Handle(DoPomodoro request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(request.PomodorableId);

            book.DoPomodoro();

            await _bookRepository.SaveChangesAsync();

            await _messageService.PublishAsync(new PomodoroDone(DateTimeOffset.Now, book.Id));

            return Unit.Value;
        }
    }
}
