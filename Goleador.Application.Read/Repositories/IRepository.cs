using Goleador.Application.Read.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Application.Read.Repositories
{
    public interface IRepository<T> where T : ReadModel
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task InsertOneAsync(T entity);
        Task<T> GetAsync(Guid id);
        Task UpdateAsync(Guid id, Dictionary<string, object> fieldValuePairs);
    }
}
