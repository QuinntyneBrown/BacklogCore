using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using System;
using System.Security.Cryptography;

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

    public class CreatedUser : BaseDomainEvent
    {
        public Guid UserId { get; private set; }

        public CreatedUser(Guid userId)
        {
            UserId = userId;
        }
    }

    public class CreateUser : BaseDomainEvent
    {
        public Guid UserId { get; private set; } = Guid.NewGuid();
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Byte[] Salt { get; private set; }

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

    public class BuildToken : BaseDomainEvent
    {
        public BuildToken(string username)
        {
            Username = username;
        }
        public string Username { get; private set; }
    }

    public class BuiltToken : BaseDomainEvent
    {
        public BuiltToken(Guid userId, string accessToken)
        {
            UserId = userId;
            AccessToken = accessToken;
        }
        public Guid UserId { get; private set; }
        public string AccessToken { get; private set; }

        public void Deconstruct(out Guid userId, out string accessToken)
        {
            userId = UserId;
            accessToken = AccessToken;
        }
    }
}
