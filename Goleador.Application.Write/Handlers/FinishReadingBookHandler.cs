using Goleador.Application.Messages.Messages;
using Goleador.Application.Write.Commands;
using Goleador.Domain.Base;
using Goleador.Domain.Book;
using Goleador.Infrastructure.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goleador.Application.Write.Handlers
{
    public class FinishReadingBookHandler : IRequestHandler<FinishReadingBook>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMessageService _messageService;

        public FinishReadingBookHandler(IRepository<Book> bookRepository, IMessageService messageService)
        {
            _bookRepository = bookRepository;
            _messageService = messageService;
        }

        public async Task<Unit> Handle(FinishReadingBook request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(request.Id);

            book.FinishReading();

            await _bookRepository.SaveChangesAsync();

            await _messageService.PublishAsync(new ReadingBookFinished(book.Id));

            return Unit.Value;
        }
    }
}
