using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Application.Read.Models
{
    public class Pomodoro
    {
        public Guid Id { get; set; }
        public DateTimeOffset Done { get; set; }
    }
}
