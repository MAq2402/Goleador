using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Domain.Base;
using Goleador.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Goleador.Infrastructure.Repositories
{
    public class WriteRepository<T> : IRepository<T> where T : AggregateRoot
    {
        private readonly GoleadorDbContext _dbContext;

        public WriteRepository(GoleadorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T aggregateRoot)
        {
            await _dbContext.AddAsync(aggregateRoot);
        }

        public async Task RemoveAsync(T aggregateRoot)
        {
            _dbContext.Remove(aggregateRoot);
            await Task.FromResult(0);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Guid aggregateRootId)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(ar => ar.Id == aggregateRootId);
        }
    }
}