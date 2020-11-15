using Goleador.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Application.Messages.Messages
{
    public class ReadingBookFinished : IMessage
    {
        public ReadingBookFinished(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
        public Guid AggregateId => Id;
    }
}
