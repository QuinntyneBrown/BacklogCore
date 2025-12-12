using Microsoft.EntityFrameworkCore;
using System;

namespace Backlog.Core;

[Owned]
public class SprintStory
{
    public Guid StoryId { get; set; }
}
