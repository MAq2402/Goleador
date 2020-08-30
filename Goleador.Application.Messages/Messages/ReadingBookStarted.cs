using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Infrastructure.Types;

namespace Goleador.Application.Messages.Messages
{
    public class ReadingBookStarted : IMessage
    {
        public ReadingBookStarted(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
