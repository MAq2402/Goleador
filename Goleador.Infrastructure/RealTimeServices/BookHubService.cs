using Goleador.Application.Read.Models;
using Goleador.Application.Read.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
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

        public async Task SendAsync(IEnumerable<Book> books, string userId)
        {
            await _hubContext.Clients.User(userId).SendAsync("books", books);
        }
    }
}
