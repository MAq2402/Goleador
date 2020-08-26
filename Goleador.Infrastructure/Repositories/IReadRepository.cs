using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Infrastructure.Repositories
{
    public interface IReadRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task InsertOneAsync(T entity);
    }
}
