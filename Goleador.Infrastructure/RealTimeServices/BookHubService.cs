using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections.Client;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Infrastructure.RealTimeServices
{
    public class BookHubService : IBookHubService
    {
        private readonly IHubContext<BookHub> _hubContext;

        public BookHubService(IHubContext<BookHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendAsync(object data, string userId)
        {
            await _hubContext.Clients.User(userId).SendAsync("books", data);
        }
    }
}
