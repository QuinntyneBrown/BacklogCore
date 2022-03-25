using Backlog.SharedKernel;

namespace Backlog.Api.DomainEvents
{
    public class CreatedUser : BaseDomainEvent
    {
        public Guid UserId { get; private set; }

        public CreatedUser(Guid userId)
        {
            UserId = userId;
        }
    }
}
