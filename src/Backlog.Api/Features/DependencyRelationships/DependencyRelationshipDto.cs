using System;

namespace Backlog.Api.Features
{
    public class DependencyRelationshipDto
    {
        public Guid DependencyRelationshipId { get; set; }
        public Guid TargetId { get; set; }
        public Guid DependsOnId { get; set; }
    }
}
