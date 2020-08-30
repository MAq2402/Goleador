using System;
using System.Collections.Generic;
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
    public class StartReadingBookHandler : IRequestHandler<StartReadingBook>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMessageService _messageService;

        public StartReadingBookHandler(IRepository<Book> bookRepository, IMessageService messageService)
        {
            _bookRepository = bookRepository;
            _messageService = messageService;
        }

        public async Task<Unit> Handle(StartReadingBook request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(request.Id);

            book.StartReading();

            await _bookRepository.SaveChangesAsync();

            await _messageService.PublishAsync(new ReadingBookStarted(book.Id));

            return Unit.Value;
        }
    }
}