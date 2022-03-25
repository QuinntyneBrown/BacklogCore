using Backlog.SharedKernel;

namespace Backlog.Core
{
    public class CreateTaskItem : BaseDomainEvent
    {
        public Guid TaskItemId { get; set; } = Guid.NewGuid();
    }
}
