using Backlog.Api.Core;
using System;

namespace Backlog.Api.Models
{
    public class Difficulty: AggregateRoot
    {
        public Guid DifficultyId { get; private set; }
        public string Value { get; private set; }

        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event)
        {

        }
    }
}
