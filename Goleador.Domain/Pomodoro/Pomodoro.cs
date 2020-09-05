using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Domain.Base;

namespace Goleador.Domain.Pomodoro
{
    public class Pomodoro : ValueObject
    {
        public Pomodoro()
        {
            Done = DateTimeOffset.Now;
        }

        public DateTimeOffset Done { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Done;
        }
    }
}
