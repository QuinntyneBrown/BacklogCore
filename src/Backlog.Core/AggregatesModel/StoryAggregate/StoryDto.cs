using System;
using System.Collections.Generic;

namespace Backlog.Core;
public class StoryDto
{
    public Guid? StoryId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string AcceptanceCriteria { get; set; }
    public string JiraUrl { get; set; }
    public List<string> DependsOn { get; set; } = new List<string>();
    public string Status { get; set; }
    public int Effort { get; set; }
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