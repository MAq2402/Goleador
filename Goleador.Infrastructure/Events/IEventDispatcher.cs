using Goleador.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Infrastructure.Events
{
    public interface IEventDispatcher
    {
        Task DispatchAsync<T>(T @event) where T : IEvent;
    }
}
