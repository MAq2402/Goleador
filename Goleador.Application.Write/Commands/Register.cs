using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Application.Write.Commands
{
    public class Register : IRequest
    {
        public Register(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; }
        public string Password { get; }
    }
}
