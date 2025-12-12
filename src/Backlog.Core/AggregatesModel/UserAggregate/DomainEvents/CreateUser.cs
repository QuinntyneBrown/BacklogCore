using Backlog.SharedKernel;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace Backlog.Core;
public class CreateUser : BaseDomainEvent
{
    public Guid UserId { get; private set; } = Guid.NewGuid();
    public string? Username { get; private set; }
    public string? Password { get; private set; }
    public Byte[]? Salt { get; private set; }

    [JsonConstructor]
    public CreateUser()
    {

    }

    public CreateUser(string username, string password, IPasswordHasher passwordHasher)
    {
        Salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(Salt);
        }
        Username = username;
        Password = passwordHasher.HashPassword(Salt, password);

    }
}
}
