using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Infrastructure.Types;

namespace Goleador.Application.Messages.Handlers
{
    public interface IMessageHandler<in T> where T : IMessage
    {
        Task HandleAsync(T message);
    }
}
