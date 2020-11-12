using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Infrastructure.Auth;

namespace OccBooking.Auth.Services
{
    public interface IJwtFactory
    {
        string GenerateJwt(string userId);
    }
}
