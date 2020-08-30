using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Infrastructure.Types;

namespace Goleador.Infrastructure.Repositories
{
    public interface IReadRepository<T> where T : ReadModel
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task InsertOneAsync(T entity);
        Task<T> GetAsync(Guid id);
        Task UpdateAsync(Guid id, Dictionary<string, string> fieldValuePairs);
    }
}
