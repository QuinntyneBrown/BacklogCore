using Backlog.SharedKernel;

namespace Backlog.Core;
public class CreateBug : BaseDomainEvent
{
    public Guid BugId { get; private set; } = Guid.NewGuid();
    public CreateBug()
    {

    }
}