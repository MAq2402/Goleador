using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Goleador.Application.Write.Commands
{
    public class DoPomodoro : IRequest
    {
        public DoPomodoro(Guid pomodorableId)
        {
            PomodorableId = pomodorableId;
        }

        public Guid PomodorableId { get; }
    }
}
