using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Application.Read.Models;

namespace Goleador.Application.Read.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> BooksWithPomodorosAsync(string userId, string status = null);
        Task<Book> BookWithPomodorosAsync(Guid id);
        Task<string> GetUserId(Guid bookId);
    }
}
