using System;

namespace Backlog.Api.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(Byte[] salt, string password);
    }
}
