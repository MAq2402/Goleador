using Goleador.Application.Contracts.Models;
using Goleador.Application.Contracts.Services;
using Goleador.Application.Read.Models;
using Goleador.Application.Read.Queries;
using Goleador.Application.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goleador.Application.Read.Handlers
{
    public class LoginHandler : IRequestHandler<LoginQuery, User>
    {
        private readonly IAuthService _authService;

        public LoginHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<User> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await _authService.LoginAsync(request.UserName, request.Password) ??
                throw new NotFoundException($"User with given credentails does not exist.");
        }
    }
}
