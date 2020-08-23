using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Domain.Base
{
    public interface IRepository<T> where T : AggregateRoot
    {
        Task AddAsync(T aggregateRoot);
        Task RemoveAsync(T aggregateRoot);
        Task SaveChangesAsync();
        Task<T> GetAsync(Guid aggregateRootId);
    }
}
