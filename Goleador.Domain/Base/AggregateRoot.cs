using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Domain.Base
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IEvent> _events = new List<IEvent>();
        public IEnumerable<IEvent> Events => _events;

        protected AggregateRoot(Guid id) : base(id)
        {
        }

        protected AggregateRoot() : base()
        {
        }

        protected void AddEvent(IEvent @event)
        {
            _events.Add(@event);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}
