using Backlog.SharedKernel;

namespace Backlog.Core
{
    public class User
    {
        public Guid UserId { get; private set; }
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public byte[] Salt { get; private set; } = Array.Empty<byte>();
        public bool IsDeleted { get; private set; }
        public User(CreateUser @event)
        {
            

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
