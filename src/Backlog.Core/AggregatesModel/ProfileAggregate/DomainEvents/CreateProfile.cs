using System;
using Backlog.SharedKernel;

namespace Backlog.Core;

public class CreateProfile : BaseDomainEvent
{
    public Guid ProfileId { get; private set; } = Guid.NewGuid();
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public CreateProfile(string firstname, string lastname)
    {
        Firstname = firstname;
        Lastname = lastname;
    }
}