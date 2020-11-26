using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Domain.Base;
using Goleador.Infrastructure.DbContext;
using Goleador.Infrastructure.Events;
using Microsoft.EntityFrameworkCore;

namespace Goleador.Infrastructure.Repositories
{
    public class EfCoreWriteRepository<T> : IRepository<T> where T : AggregateRoot
    {
        private readonly GoleadorDbContext _dbContext;
        private readonly IEventDispatcher _eventDispatcher;

        public EfCoreWriteRepository(GoleadorDbContext dbContext, IEventDispatcher eventDispatcher)
        {
            _dbContext = dbContext;
            _eventDispatcher = eventDispatcher;
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

        public async Task SaveChangesAsync(T aggregateRoot)
        {
            await _dbContext.SaveChangesAsync();

            foreach(var @event in aggregateRoot.Events)
            {
                await _eventDispatcher.DispatchAsync(@event);
            }
        }

        public async Task<T> GetAsync(Guid aggregateRootId)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(ar => ar.Id == aggregateRootId);
        }
    }
}