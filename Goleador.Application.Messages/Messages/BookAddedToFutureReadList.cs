using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Infrastructure.Types;

namespace Goleador.Application.Messages.Messages
{
    public class BookAddedToFutureReadList : IMessage
    {
        public BookAddedToFutureReadList(Guid id, string name, string author, string status, DateTimeOffset created)
        {
            Id = id;
            Name = name;
            Author = author;
            Status = status;
            Created = created;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Author { get; }
        public string Status { get; }
        public DateTimeOffset Created { get; }
    }
}