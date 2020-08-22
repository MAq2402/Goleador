using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goleador.Domain.Base;
using Goleador.Domain.Pomodoro;

namespace Goleador.Domain.Book
{
    public class Book : AggregateRoot
    {
        private readonly List<Pomodoro.Pomodoro> _pomodoros = new List<Pomodoro.Pomodoro>();

        public Book(string name, string author)
        {
            Name = name;
            Author = author;
            Status = BookStatus.ToRead;
            Created = DateTimeOffset.Now;
        }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public BookStatus Status { get; private set; }
        public DateTimeOffset Created { get; private set; }
        public DateTimeOffset ReadingStarted { get; private set; }
        public DateTimeOffset ReadingFinished { get; private set; }
        public IEnumerable<Pomodoro.Pomodoro> Pomodoros => _pomodoros.AsEnumerable();

        public void StartReading()
        {
            if (Status != BookStatus.ToRead)
            {
                throw new InvalidOperationException("The book is in read or has been already finished");
            }

            Status = BookStatus.InRead;
            ReadingStarted = DateTimeOffset.Now;
        }

        public void FinishReading()
        {
            if (Status != BookStatus.ToRead)
            {
                throw new InvalidOperationException("The book is in to read list or has been already finished");
            }

            Status = BookStatus.Finished;
            ReadingFinished = DateTimeOffset.Now;
        }

        public void DoPomodoro()
        {
            if (Status != BookStatus.InRead)
            {
                throw new InvalidOperationException("Pomodoro can be only done on book that is in read state");
            }

            _pomodoros.Add(new Pomodoro.Pomodoro());
        }
    }
}
