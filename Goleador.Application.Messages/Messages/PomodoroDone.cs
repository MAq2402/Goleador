using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Infrastructure.Types;

namespace Goleador.Application.Messages.Messages
{
    public class PomodoroDone : IMessage
    {
        public PomodoroDone(DateTimeOffset done, Guid pomodorableId)
        {
            Done = done;
            PomodorableId = pomodorableId;
        }

        public DateTimeOffset Done { get; }
        public Guid PomodorableId { get; }

        public Guid AggregateId => PomodorableId;
    }
}