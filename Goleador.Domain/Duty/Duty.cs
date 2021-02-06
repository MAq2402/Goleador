using Goleador.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Domain.Duty
{
    public class Duty : AggregateRoot
    {
        private Duty(Guid bookId, int requiredPomodoros, string userId) : base(Guid.NewGuid())
        {
            BookId = bookId;
            RequiredPomodoros = requiredPomodoros;
            UserId = userId;
            Done = false;
        }

        private Duty(string name, int requiredPomodoros, string userId) : base(Guid.NewGuid())
        {
            Name = name;
            RequiredPomodoros = requiredPomodoros;
            UserId = userId;
            Done = false;
        }

        public static Duty StandardDuty(string name, int requiredPomodoros, string userId)
        {
            return new Duty(name, requiredPomodoros, userId);
        }

        public static Duty BookDuty(Guid bookId, int requiredPomodoros, string userId)
        {
            return new Duty(bookId, requiredPomodoros, userId);
        }

        public bool Done { get; }
        public string Name { get; }
        public Guid? BookId { get; }
        public int RequiredPomodoros { get; }
        public IEnumerable<Pomodoro.Pomodoro> Pomodoros { get; }
        public string UserId { get; private set; }

        //Value object albo wgl do wywalenia
        public float Progress { get; }
        public bool IsStandard => !BookId.HasValue;
    }
}
