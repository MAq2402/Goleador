using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Application.Read.Models;
using Goleador.Infrastructure.Repositories;

namespace Goleador.Application.Read.Repositories
{
    public interface IBookRepository : IReadRepository<Book>
    {
        Task<IEnumerable<Book>> BooksWithPomodorosAsync();
        Task<Book> BookWithPomodorosAsync(Guid requestId);
    }
}
