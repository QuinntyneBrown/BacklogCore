using Backlog.Api.Core;

namespace Backlog.Api.DomainEvents
{
    public class CreateTaskItem : BaseDomainEvent
    {
        public Guid TaskItemId { get; set; } = Guid.NewGuid();
    }
}
