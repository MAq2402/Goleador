using Goleador.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Domain.Book.Events
{
    public class PomodoroDone : IEvent
    {
        public PomodoroDone(DateTimeOffset done, Guid aggregateId)
        {
            Done = done;
            AggregateId = aggregateId;
        }

        private PomodoroDone()
        {

        }

        public DateTimeOffset Done { get; }
        public Guid AggregateId { get; }
    }
}
