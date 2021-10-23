using Backlog.Api.Core;
using System;

namespace Backlog.Api.Models
{
    public class CompentencyLevel: AggregateRoot
    {
        public Guid CompentencyLevelId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event)
        {

        }
    }
}
