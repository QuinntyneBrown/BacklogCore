using System;

namespace Backlog.SharedKernel;
public interface IPasswordHasher
{
    string HashPassword(Byte[] salt, string password);
}
}
