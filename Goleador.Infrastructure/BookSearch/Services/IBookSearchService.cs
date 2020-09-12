using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Infrastructure.BookSearch.Models;

namespace Goleador.Infrastructure.BookSearch.Services
{
    public interface IBookSearchService
    {
        Task<BookResponse> SearchAsync(string query);
    }
}
