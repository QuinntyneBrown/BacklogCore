using System;
using System.Collections.Generic;

namespace Backlog.Core;

public class StoryDto
{
    public Guid? StoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AcceptanceCriteria { get; set; } = string.Empty;
    public string JiraUrl { get; set; } = string.Empty;
    public List<string> DependsOn { get; set; } = [];
    public string Status { get; set; } = string.Empty;
    public int Effort { get; set; } = 0;
    public List<SkillRequirementDto> SkillRequirements { get; set; } = new List<SkillRequirementDto>();

    public StoryDto()
    {

    }

    public StoryDto(string name, string title, string description, string acceptanceCriteria, string status, int effort)
    {
        Name = name;
        Title = title;
        Description = description;
        AcceptanceCriteria = acceptanceCriteria;
        Status = status;
        Effort = effort;
    }

    public StoryDto(Guid storyId, string name, string title, string description, string acceptanceCriteria, string status, int effort)
        : this(name, title, description, acceptanceCriteria,status, effort)
    {
        StoryId = storyId;
    }
}