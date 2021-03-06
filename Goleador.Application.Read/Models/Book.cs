﻿using System;
using System.Collections.Generic;

namespace Goleador.Application.Read.Models
{
    public class Book : ReadModel
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Status { get; set; }
        public string Thumbnail { get; set; }
        public string PublishedYear { get; set; }
        public string ExternalId { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? ReadingStarted { get; set; }
        public DateTimeOffset? ReadingFinished { get; set; }
        public IEnumerable<Pomodoro> Pomodoros { get; set; }
    }
}
