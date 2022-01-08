using Backlog.Api.Core;
using Backlog.Api.DomainEvents;
using Backlog.Api.Interfaces;
using System;

namespace Backlog.Api.Models
{
    public class User: AggregateRoot
    {
        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public byte[] Salt { get; private set; }
        public bool IsDeleted { get; private set; }
        public User(CreateUser @event)
        {
            Apply(@event);

        }

        private User()
        {

        }


        public User ChangePassword(string oldPassword, string newPassword, IPasswordHasher passwordHasher)
        {
            if (Password != passwordHasher.HashPassword(Salt, oldPassword))
            {
                throw new Exception("Old password is invalid");
            }

            var newPasswordHash = passwordHasher.HashPassword(Salt, newPassword);

            if (Password == newPassword)
            {
                throw new Exception("Changed password is equal to old password");
            }

            Password = newPasswordHash;

            return this;
        }

        public User SetPassword(string password, IPasswordHasher passwordHasher)
        {
            Password = passwordHasher.HashPassword(Salt, password);

            return this;
        }

        public User SetUsername(string username)
        {
            Username = username;

            return this;
        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateUser @event)
        {
            UserId = @event.UserId;
            Salt = @event.Salt;
            Password = @event.Password;
            Username = @event.Username;
        }

        protected override void EnsureValidState()
        {

        }
    }
}
