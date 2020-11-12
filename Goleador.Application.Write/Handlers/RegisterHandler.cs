using Goleador.Application.Contracts.Services;
using Goleador.Application.Write.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goleador.Application.Write.Handlers
{
    public class RegisterHandler : IRequestHandler<Register>
    {
        private readonly IAuthService _authService;

        public RegisterHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Unit> Handle(Register request, CancellationToken cancellationToken)
        {
            await _authService.RegisterAsync(request.UserName, request.Password);

            return Unit.Value;
        }
    }
}
