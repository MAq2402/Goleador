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

        public Book(string title, string authors, string thumbnail, 
            string publishedYear, string externalId, string userId)
        {
            Title = title;
            Authors = authors;
            Thumbnail = thumbnail;
            PublishedYear = publishedYear;
            ExternalId = externalId;
            Status = BookStatus.ToRead;
            Created = DateTimeOffset.Now;
            UserId = userId;
        }

        public string Title { get; private set; }
        public string Authors { get; private set; }
        public string Thumbnail { get; private set; }
        public string PublishedYear { get; private set; }
        public string ExternalId { get; private set; }
        public BookStatus Status { get; private set; }
        public DateTimeOffset Created { get; private set; }
        public DateTimeOffset? ReadingStarted { get; private set; }
        public DateTimeOffset? ReadingFinished { get; private set; }
        public IEnumerable<Pomodoro.Pomodoro> Pomodoros => _pomodoros.AsEnumerable();
        public string UserId { get; private set; }

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
            if (Status != BookStatus.InRead)
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
