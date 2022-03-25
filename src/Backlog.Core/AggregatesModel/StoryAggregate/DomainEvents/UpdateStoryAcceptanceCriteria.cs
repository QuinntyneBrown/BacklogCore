using Backlog.SharedKernel;

namespace Backlog.Core
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
