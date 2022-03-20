using Backlog.Api.Core;

namespace Backlog.Api.DomainEvents
{
    public class UpdateStoryStatus : BaseDomainEvent
    {
        public string Status { get; private set; }

        public UpdateStoryStatus(string status)
        {
            Status = status;
        }
    }
}
