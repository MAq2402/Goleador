using Goleador.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Application.Write.EventHandlers
{
    public class EventHandler<T> : IEventHandler<T> where T : IEvent
    {
        public Task HandleAsync(T @event)
        {
            return Task.FromResult(0);
        }
    }
}
