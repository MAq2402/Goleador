using Autofac;
using Goleador.Domain.Base;
using Goleador.Infrastructure.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Infrastructure.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IComponentContext _context;
        private readonly IMessageService _messageService;

        public EventDispatcher(IComponentContext context, IMessageService messageService)
        {
            _context = context;
            _messageService = messageService;
        }

        public async Task DispatchAsync<T>(T @event) where T : IEvent
        {
            var handlerType = typeof(IEventHandler<>)
                    .MakeGenericType(@event.GetType());

            if(_context.IsRegistered(handlerType))
            {
                dynamic handler = _context.Resolve(handlerType);
                await handler.HandleAsync((dynamic)@event);
            }

            await _messageService.PublishAsync(@event);
        }
    }
}
