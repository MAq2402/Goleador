using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goleador.Domain.Base;
using Goleador.Domain.Book.Events;
using Goleador.Domain.Exceptions;

namespace Goleador.Domain.Book
{
    public class Book : AggregateRoot
    {
        private readonly List<Pomodoro.Pomodoro> _pomodoros = new List<Pomodoro.Pomodoro>();

        public Book(string title, string authors, string thumbnail, 
            string publishedYear, string externalId, string userId) : base(Guid.NewGuid())
        {
            Title = title;
            Authors = authors;
            Thumbnail = thumbnail;
            PublishedYear = publishedYear;
            ExternalId = externalId;
            Status = BookStatus.ToRead;
            Created = DateTimeOffset.Now;
            UserId = userId;

            AddEvent(new BookCreated(Id, Title, Authors,
                Thumbnail, PublishedYear, ExternalId, "To read", Created, UserId));
        }

        private Book()
        {

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
                throw new DomainException("The book is in read or has been already finished");
            }

            Status = BookStatus.InRead;
            ReadingStarted = DateTimeOffset.Now;

            AddEvent(new ReadingBookStarted(Id, ReadingStarted.Value));
        }

        public void FinishReading()
        {
            if (Status != BookStatus.InRead)
            {
                throw new DomainException("The book is in to read list or has been already finished");
            }

            Status = BookStatus.Finished;
            ReadingFinished = DateTimeOffset.Now;

            AddEvent(new ReadingBookFinished(Id, ReadingFinished.Value));
        }

        public void DoPomodoro()
        {
            if (Status != BookStatus.InRead)
            {
                throw new DomainException("Pomodoro can be only done on book that is in read state");
            }

            var pomodoro = new Pomodoro.Pomodoro();

            _pomodoros.Add(pomodoro);

            AddEvent(new PomodoroDone(pomodoro.Done, Id));
        }
    }
}
