using Backlog.SharedKernel;

namespace Backlog.Core;
public class CreatedUser : BaseDomainEvent
{
    public Guid UserId { get; private set; }

    public CreatedUser(Guid userId)
    {
        UserId = userId;
    }
}