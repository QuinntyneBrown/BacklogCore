using System;
using Backlog.Core;

namespace Backlog.Core
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new ()
            {
                UserId = user.UserId,
                Username = user.Username
            };
        }
        
    }
}
