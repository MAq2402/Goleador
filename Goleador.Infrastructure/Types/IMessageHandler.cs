using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Infrastructure.Types
{
    public interface IMessageHandler<in T> where T : IMessage
    {
        Task HandleAsync(T message);
    }
}
