using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goleador.Infrastructure.Types;

namespace Goleador.Web.Dispatchers
{
    public interface IMessageDispatcher
    {
        Task DispatchAsync<T>(T message) where T : IMessage;
    }
}
