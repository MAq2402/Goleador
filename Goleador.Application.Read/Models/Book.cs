using System;
using System.Collections.Generic;
using Goleador.Infrastructure.Types;

namespace Goleador.Application.Read.Models
{
    public class Book : ReadModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? ReadingStarted { get; set; }
        public DateTimeOffset? ReadingFinished { get; set; }
        public IEnumerable<Pomodoro> Pomodoros { get; set; }
    }
}
