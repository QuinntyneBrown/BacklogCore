

namespace Backlog.Core
{

    public class AddSprintStory: BaseDomainEvent
    {
        public Guid StoryId { get; private set; }

        public AddSprintStory(Guid storyId)
        {
            StoryId = storyId;
        }
    }
}
