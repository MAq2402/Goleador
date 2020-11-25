using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goleador.Domain.Base;

namespace Goleador.Web.Dispatchers
{
    public interface IMessageDispatcher
    {
        Task DispatchAsync<T>(T @event) where T : IEvent;
    }
}
