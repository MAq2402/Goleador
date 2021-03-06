﻿using Goleador.Application.Read.Models;
using Goleador.Application.Shared.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Application.Read.Queries
{
    public class LoginQuery : IRequest<User>
    {
        public LoginQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; }
        public string Password { get; }
    }
}
