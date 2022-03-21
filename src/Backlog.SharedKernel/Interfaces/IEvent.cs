using MediatR;

namespace Backlog.SharedKernel
{
    public interface IEvent : INotification
    {
        DateTime Created { get; }
        Guid CorrelationId { get; }
        Dictionary<string, object> Items { get; }
    }
}
