using Goleador.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Domain.Book.Events
{
    public class ReadingBookStarted : IEvent
    {
        public ReadingBookStarted(Guid aggregateId, DateTimeOffset occuredOn)
        {
            AggregateId = aggregateId;
            OccuredOn = occuredOn;
        }

        public Guid AggregateId { get; }
        public DateTimeOffset OccuredOn { get; }
    }
}
