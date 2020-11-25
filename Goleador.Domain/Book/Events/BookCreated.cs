using Goleador.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Domain.Book.Events
{
    public class BookCreated : IEvent
    {
        public BookCreated(Guid aggregateId,
            string title,
            string authors,
            string thumbnail,
            string publishedYear,
            string externalId,
            string status,
            DateTimeOffset created,
            string userId)
        {
            AggregateId = aggregateId;
            Title = title;
            Authors = authors;
            Thumbnail = thumbnail;
            PublishedYear = publishedYear;
            ExternalId = externalId;
            Status = status;
            Created = created;
            UserId = userId;
        }

        public string Title { get; }
        public string Authors { get; }
        public string Thumbnail { get; }
        public string PublishedYear { get; }
        public string ExternalId { get; }
        public string Status { get; }
        public DateTimeOffset Created { get; }
        public string UserId { get; }
        public Guid AggregateId { get; }
    }
}
