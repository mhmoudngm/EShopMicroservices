using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Abstractions
{
    public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
    {
        private readonly List<IDomainEvent> _domainevents = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainevents.AsReadOnly();
        public void AddDomainEvent(IDomainEvent domainevent)
        {
            _domainevents.Add(domainevent); 
        }
        public IDomainEvent[] ClearDomainEvents()
        {
            IDomainEvent[] dequeuedEvents = _domainevents.ToArray();
            _domainevents.Clear();
            return dequeuedEvents;
        }
    }
}
