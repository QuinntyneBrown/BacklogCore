using Backlog.SharedKernel;
using static System.String;

namespace Backlog.Core
{
    public class Story : AggregateRoot
    {
        public Guid StoryId { get; private set; }
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string AcceptanceCriteria { get; private set; }
        public string JiraUrl { get; private set; }
        public string Status { get; private set; } = Empty;
        public int Effort { get; private set; }
        public List<DependencyRelationship> DependsOn { get; private set; }
        public List<SkillRequirement> SkillRequirements { get; private set; }
        public List<Attachment> Attachments { get; private set; }

        public Story(CreateStory @event)
        {
            Apply(@event);
        }

        private Story()
        {

        }
        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateStory @event)
        {
            StoryId = @event.StoryId;
            Title = @event.Title;
            Name = @event.Name;
            Description = @event.Description;
            AcceptanceCriteria = @event.AcceptanceCriteria;
            JiraUrl = @event.JiraUrl;
            Status = StoryStatus.Backlog;
            DependsOn = new List<DependencyRelationship>();
            SkillRequirements = new List<SkillRequirement>();
            Attachments = new List<Attachment>();
            Effort = @event.Effort;
        }

        private void When(UpdateStory @event)
        {
            Title = @event.Title;
            Name = @event.Name;
            Description = @event.Description;
            AcceptanceCriteria = @event.AcceptanceCriteria;
            JiraUrl = @event.JiraUrl;
            Effort = @event.Effort;
        }

        private void When(UpdateStoryJiraUrl @event)
        {
            JiraUrl = @event.JiraUrl;
        }

        private void When(AddSkillRequirement @event)
        {
            SkillRequirements.Add(@event.SkillRequirement);
        }

        private void When(UpdateDependsOn @event)
        {
            DependsOn = @event.DependsOn;
        }

        private void When(UpdateStoryStatus @event)
        {
            Status = @event.Status;
        }

    }
}
