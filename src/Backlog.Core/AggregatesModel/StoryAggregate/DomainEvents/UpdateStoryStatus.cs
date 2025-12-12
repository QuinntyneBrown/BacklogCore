using Backlog.SharedKernel;

namespace Backlog.Core;

public class UpdateStoryStatus : BaseDomainEvent
{
    public string Status { get; private set; }

    public UpdateStoryStatus(string status)
    {
        Status = status;
    }
}