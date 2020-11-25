using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Domain.Base;
using Goleador.Infrastructure.Types;

namespace Goleador.Infrastructure.Messages
{
    public interface IMessageService
    {
        Task PublishAsync(IEvent @event);
    }
}
