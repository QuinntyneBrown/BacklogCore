using Backlog.Api.Core;

namespace Backlog.Api.DomainEvents
{
    public class UpdateStoryJiraUrl : BaseDomainEvent
    {
        public string JiraUrl { get; private set; }

        public UpdateStoryJiraUrl(string jiraUrl)
        {
            JiraUrl = jiraUrl;
        }
    }
}
