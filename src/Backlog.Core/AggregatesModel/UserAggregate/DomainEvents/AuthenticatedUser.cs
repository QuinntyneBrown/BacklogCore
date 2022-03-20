using Backlog.Api.Core;

namespace Backlog.Api.DomainEvents
{
    public class AuthenticatedUser : BaseDomainEvent
    {
        public AuthenticatedUser(string username)
        {
            Username = username;
        }
        public string Username { get; private set; }
    }
}
