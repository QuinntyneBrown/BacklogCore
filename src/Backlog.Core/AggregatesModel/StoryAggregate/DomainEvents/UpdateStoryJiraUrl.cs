using Backlog.SharedKernel;

namespace Backlog.Core;
public class UpdateStoryJiraUrl : BaseDomainEvent
{
    public string JiraUrl { get; private set; }

    public UpdateStoryJiraUrl(string jiraUrl)
    {
        JiraUrl = jiraUrl;
    }
}
}
