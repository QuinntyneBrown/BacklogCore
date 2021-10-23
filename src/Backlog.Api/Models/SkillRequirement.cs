using Backlog.Api.Core;
using System;

namespace Backlog.Api.Models
{
    public class SkillRequirement: AggregateRoot
    {
        public Guid SkillRequirementId { get; private set; }
        public string Technology { get; private set; }
        public string CompentencyLevel { get; set; }

        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event)
        {

        }
    }
}
