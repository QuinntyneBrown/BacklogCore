using Backlog.Api.Core;

namespace Backlog.Api.DomainEvents
{
    public class UpdateStoryAcceptanceCriteria : BaseDomainEvent
    {
        public string AcceptanceCriteria { get; private set; }

        public UpdateStoryAcceptanceCriteria(string acceptanceCriteria)
        {
            AcceptanceCriteria = acceptanceCriteria;
        }
    }
}
