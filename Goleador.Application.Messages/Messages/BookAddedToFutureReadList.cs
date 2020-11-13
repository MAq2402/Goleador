using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Infrastructure.Types;

namespace Goleador.Application.Messages.Messages
{
    public class BookAddedToFutureReadList : IMessage
    {
        public BookAddedToFutureReadList(Guid id,
            string title,
            string authors, 
            string thumbnail,
            string publishedYear,
            string externalId,
            string status, 
            DateTimeOffset created,
            string userId)
        {
            Id = id;
            Title = title;
            Authors = authors;
            Thumbnail = thumbnail;
            PublishedYear = publishedYear;
            ExternalId = externalId;
            Status = status;
            Created = created;
            UserId = userId;
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Authors { get; }
        public string Thumbnail{ get; }
        public string PublishedYear { get; }
        public string ExternalId { get; }
        public string Status { get; }
        public DateTimeOffset Created { get; }
        public string UserId { get; }
    }
}