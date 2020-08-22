using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Domain.Base;

namespace Goleador.Domain.Pomodoro
{
    public class Pomodoro : Entity
    {
        public Pomodoro()
        {
            Done = DateTimeOffset.Now;
        }

        public DateTimeOffset Done { get; private set; }
        public Book.Book Book { get; private set; }
    }
}
