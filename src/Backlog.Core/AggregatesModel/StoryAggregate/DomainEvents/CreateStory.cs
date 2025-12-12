using Backlog.SharedKernel;

namespace Backlog.Core;

public class CreateStory : BaseDomainEvent
{
    public Guid StoryId { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string AcceptanceCriteria { get; private set; }
    public string Status { get; private set; }
    public string JiraUrl { get; private set; }
    public int Effort { get; set; }

    public CreateStory(
        string name,
        string title,
        string description,
        string acceptanceCriteria,
        string jiraUrl,
        int effort)
    {
        Name = name;
        Title = title;
        Description = description;
        AcceptanceCriteria = acceptanceCriteria;
        JiraUrl = jiraUrl;
        Effort = effort;
    }
}