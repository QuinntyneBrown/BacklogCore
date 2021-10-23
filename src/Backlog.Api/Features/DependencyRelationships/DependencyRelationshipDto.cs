using System;

namespace Backlog.Api.Features
{
    public class DependencyRelationshipDto
    {
        public Guid DependencyRelationshipId { get; set; }
        public string Target { get; set; }
        public string DependsOn { get; set; }
    }
}
