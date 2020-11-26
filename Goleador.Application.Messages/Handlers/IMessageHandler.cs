using Goleador.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Application.Messages.Handlers
{
    public interface IMessageHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
