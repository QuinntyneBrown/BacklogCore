using System;

namespace Backlog.Api.Features
{
    public class StatusDto
    {
        public Guid StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
