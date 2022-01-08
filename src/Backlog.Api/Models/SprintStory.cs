using Microsoft.EntityFrameworkCore;
using System;

namespace Backlog.Api.Models
{
    [Owned]
    public class SprintStory
    {
        public Guid StoryId { get; set; }
    }
}
