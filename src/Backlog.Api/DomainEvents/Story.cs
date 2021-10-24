using Backlog.Api.Core;
using Backlog.Api.Models;
using System;

namespace Backlog.Api.DomainEvents
{
    public class CreateStory : BaseDomainEvent
    {
        public Guid StoryId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string AcceptanceCriteria { get; private set; }
        public string Status { get; private set; }

        public CreateStory(
            string name,
            string title,
            string description,
            string acceptanceCriteria)
        {
            Name = name;
            Title = title;
            Description = description;
            AcceptanceCriteria = acceptanceCriteria;
        }
    }

    public class UpdateStory : BaseDomainEvent
    {
        public Guid StoryId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string AcceptanceCriteria { get; private set; }
        public string Status { get; private set; }

        public UpdateStory(
            string name,
            string title,
            string description,
            string acceptanceCriteria)
        {
            Name = name;
            Title = title;
            Description = description;
            AcceptanceCriteria = acceptanceCriteria;
        }
    }

    public class UpdateStoryAcceptanceCriteria : BaseDomainEvent
    {
        public string AcceptanceCriteria { get; private set; }

        public UpdateStoryAcceptanceCriteria(string acceptanceCriteria)
        {
            AcceptanceCriteria = acceptanceCriteria;
        }
    }

    public class UpdateStoryJiraUrl : BaseDomainEvent
    {
        public string JiraUrl { get; private set; }

        public UpdateStoryJiraUrl(string jiraUrl)
        {
            JiraUrl = jiraUrl;
        }
    }

    public class UpdateStoryDescription : BaseDomainEvent
    {
        public string Description { get; private set; }

        public UpdateStoryDescription(string description)
        {
            Description = description;
        }
    }

    public class UpdateStoryStatus : BaseDomainEvent
    {
        public string Status { get; private set; }

        public UpdateStoryStatus(string status)
        {
            Status = status;
        }
    }

    public class AddSkillRequirement : BaseDomainEvent
    {
        public SkillRequirement SkillRequirement { get; set; }

        public AddSkillRequirement(SkillRequirement skillRequirement)
        {
            SkillRequirement = skillRequirement;
        }
    }

    public class AddStoryDependsOn : BaseDomainEvent
    {
        public string DependsOn { get; set; }

        public AddStoryDependsOn(string dependsOn)
        {
            DependsOn = dependsOn;
        }
    }

    public class RemoveStoryDependsOn : BaseDomainEvent
    {
        public string DependsOn { get; set; }

        public RemoveStoryDependsOn(string dependsOn)
        {
            DependsOn = dependsOn;
        }
    }
}
