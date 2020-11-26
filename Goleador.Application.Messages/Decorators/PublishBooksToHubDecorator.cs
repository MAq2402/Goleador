using Goleador.Application.Messages.Handlers;
using Goleador.Application.Read.Repositories;
using Goleador.Application.Read.Services;
using Goleador.Domain.Base;
using System.Threading.Tasks;

namespace Goleador.Application.Messages.Decorators
{
    public class PublishBooksToHubDecorator<T> : IMessageHandler<T> where T: IEvent
    {
        private readonly IMessageHandler<T> _decorated;
        private readonly IBookHubService _hubService;
        private readonly IBookRepository _bookRepository;

        public PublishBooksToHubDecorator(IMessageHandler<T> decorated, IBookHubService hubService, IBookRepository bookRepository)
        {
            _decorated = decorated;
            _hubService = hubService;
            _bookRepository = bookRepository;
        }

        public async Task HandleAsync(T @event)
        {
            await _decorated.HandleAsync(@event);

            var userId = await _bookRepository.GetUserId(@event.AggregateId);
            await _hubService.SendAsync(await _bookRepository.BooksWithPomodorosAsync(userId), userId);
        }
    }
}
