using Backlog.Api.Core;
using Backlog.Api.DomainEvents;
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

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateSkillRequirement @event)
        {
            SkillRequirementId = @event.SkillRequirementId;
            Technology = @event.Technology;
            CompentencyLevel = @event.CompentencyLevel;

        }
        private void When(UpdateSkillRequirementTechnology @event)
        {
            Technology = @event.Technology;
        }
        private void When(UpdateSkillRequirementCompentencyLevel @event)
        {
            CompentencyLevel = @event.CompentencyLevel;
        }
        private void When(RemoveSkillRequirement @event)
        {

        }
    }
}
