using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Goleador.Application.Write.Commands
{
    public class AddBookToFutureReadListCommand : IRequest
    {
        public AddBookToFutureReadListCommand(string name, string author)
        {
            Name = name;
            Author = author;
        }

        public string Name { get; }
        public string Author { get; }
    }
}
