
using Backlog.SharedKernel;

namespace Backlog.Core
{
    public class Profile : AggregateRoot
    {
        public Guid ProfileId { get; private set; }
        public string? Firstname { get; private set; }
        public string? Lastname { get; private set; }

        public Profile(CreateProfile @event)
        {
            Apply(@event);
        }

        private Profile()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateProfile @event)
        {
            ProfileId = @event.ProfileId;
            Firstname = @event.Firstname;
            Lastname = @event.Lastname;
        }

        protected override void EnsureValidState()
        {

        }
    }
}
