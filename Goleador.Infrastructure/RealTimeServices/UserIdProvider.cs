using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goleador.Infrastructure.RealTimeServices
{
    public class UserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
        }
    }
}
