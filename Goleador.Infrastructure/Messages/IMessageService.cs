using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Infrastructure.Types;

namespace Goleador.Infrastructure.Messages
{
    public interface IMessageService
    {
        Task PublishAsync(IMessage message);
    }
}
