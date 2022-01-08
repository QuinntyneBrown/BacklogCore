using System;
using System.Collections.Generic;

namespace Backlog.Api.Features
{
    public class SprintDto
    {
        public Guid SprintId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<string> StoryIds { get; set; } = new List<string>();
    }
}
