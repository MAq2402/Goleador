using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace Goleador.Application.Read.Models
{
    public class Pomodoro : ReadModel
    {
        public DateTimeOffset Done { get; set; }
        public Guid PomodorableId { get; set; }
    }
}