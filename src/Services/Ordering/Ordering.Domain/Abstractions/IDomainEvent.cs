using MediatR;

namespace Ordering.Domain.Abstractions
{
    public interface IDomainEvent : INotification
    {
        Guid Eventid => Guid.NewGuid();
        public DateTime OccurredOn => DateTime.UtcNow;
        public string EventType => GetType().AssemblyQualifiedName;
    }
}
