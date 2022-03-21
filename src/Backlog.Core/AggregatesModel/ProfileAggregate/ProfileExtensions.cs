using Backlog.Core;

namespace Backlog.Core
{
    public static class ProfileExtensions
    {
        public static ProfileDto ToDto(this Profile profile)
        {
            return new()
            {
                ProfileId = profile.ProfileId,
                Firstname = profile.Firstname,
                Lastname = profile.Lastname
            };
        }
    }
}
