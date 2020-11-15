using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Goleador.Infrastructure.RealTimeServices
{
    [Authorize]
    public class BookHub : Hub
    {
    }
}
