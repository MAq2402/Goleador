using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Goleador.Application.Messages.Handlers;
using Goleador.Infrastructure.Types;

namespace Goleador.Web.Dispatchers
{
    public class MessageDispatcher : IMessageDispatcher
    {
        private readonly IComponentContext _context;

        public MessageDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task DispatchAsync<T>(T message) where T : IMessage
        {
            var handlerType = typeof(IMessageHandler<>)
                .MakeGenericType(message.GetType());

            dynamic handler = _context.Resolve(handlerType);

            await handler.HandleAsync((dynamic)message);
        }
    }
}
