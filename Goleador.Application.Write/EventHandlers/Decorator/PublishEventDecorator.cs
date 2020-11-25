using Goleador.Domain.Base;
using Goleador.Infrastructure.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Application.Write.EventHandlers
{
    public class PublishEventDecorator<T> : IEventHandler<T> where T : IEvent
    {
        private IEventHandler<T> _decorated;
        private IMessageService _messageService;

        public PublishEventDecorator(IEventHandler<T> decorated, IMessageService messageService)
        {
            _decorated = decorated;
            _messageService = messageService;
        }

        public async Task HandleAsync(T @event)
        {
            await _decorated.HandleAsync(@event);
            await _messageService.PublishAsync(@event);
        }
    }
}
