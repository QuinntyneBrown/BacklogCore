using Backlog.Api.Core;
using System;

namespace Backlog.Api.Models
{
    public class DependencyRelationship: AggregateRoot
    {
        public Guid DependencyRelationshipId { get; set; }

        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event)
        {

        }
    }
}
