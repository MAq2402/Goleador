using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Infrastructure.Types
{
    public interface IMessage
    {
        public Guid AggregateId { get; }
    }
}
