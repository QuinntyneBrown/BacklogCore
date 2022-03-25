

namespace Backlog.Core
{
    public class UpdateStoryDescription : BaseDomainEvent
    {
        public string Description { get; private set; }

        public UpdateStoryDescription(string description)
        {
            Description = description;
        }
    }
}
