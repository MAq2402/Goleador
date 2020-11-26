using Goleador.Application.Read.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Application.Read.Services
{
    public interface IBookHubService
    {
        Task SendAsync(IEnumerable<Book> books, string userId);
    }
}
