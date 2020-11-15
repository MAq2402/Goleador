using Goleador.Application.Messages.Handlers;
using Goleador.Application.Read.Repositories;
using Goleador.Infrastructure.RealTimeServices;
using Goleador.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Application.Messages.Decorators
{
    public class PublishBooksToHubDecorator<T> : IMessageHandler<T> where T: IMessage
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

        public async Task HandleAsync(T message)
        {
            await _decorated.HandleAsync(message);
            var userId = await _bookRepository.GetUserId(message.AggregateId);
            await _hubService.SendAsync(await _bookRepository.BooksWithPomodorosAsync(userId), userId);
        }

        //public async Task HandleAsync(IMessage message)
        //{
        //    await _messageHandler.HandleAsync(message);
        //    var userId = await _bookRepository.GetUserId(message.AggregateId);
        //    await _hubService.SendAsync(await _bookRepository.BooksWithPomodorosAsync(userId), userId);
        //}

        //public Task HandleAsync(T message)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
