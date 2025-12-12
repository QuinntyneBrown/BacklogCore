using Backlog.SharedKernel;

namespace Backlog.Core;
public class AuthenticatedUser : BaseDomainEvent
{
    public AuthenticatedUser(string username)
    {
        Username = username;
    }
    public string Username { get; private set; }
}
}
