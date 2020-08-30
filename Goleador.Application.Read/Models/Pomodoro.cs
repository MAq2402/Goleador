using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Infrastructure.Types;

namespace Goleador.Application.Read.Models
{
    public class Pomodoro : ReadModel
    {
        public DateTimeOffset Done { get; set; }
        public Guid PomodrableId { get; set; }
    }
}