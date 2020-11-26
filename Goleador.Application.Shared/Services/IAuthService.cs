using Goleador.Application.Shared.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Application.Shared.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(string userName, string password);
        Task<User> LoginAsync(string userName, string password);
    }
}
