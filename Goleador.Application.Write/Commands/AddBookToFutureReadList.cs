using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Goleador.Application.Write.Commands
{
    public class AddBookToFutureReadList : IRequest
    {
        public AddBookToFutureReadList(string title,
            IEnumerable<string> authors,
            string thumbnail,
            string publishedYear,
            string externalId,
            string userId)
        {
            Title = title;
            Authors = authors;
            Thumbnail = thumbnail;
            PublishedYear = publishedYear;
            ExternalId = externalId;
            UserId = userId;
        }

        public string Title { get; }
        public IEnumerable<string> Authors { get; }
        public string Thumbnail { get; }
        public string PublishedYear { get; }
        public string ExternalId { get; }
        public string UserId { get; }
    }
}
