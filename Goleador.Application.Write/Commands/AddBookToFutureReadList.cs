using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Goleador.Application.Write.Commands
{
    public class AddBookToFutureReadList : IRequest
    {
        public AddBookToFutureReadList(string name, string author)
        {
            Name = name;
            Author = author;
        }

        public string Name { get; }
        public string Author { get; }
    }
}
