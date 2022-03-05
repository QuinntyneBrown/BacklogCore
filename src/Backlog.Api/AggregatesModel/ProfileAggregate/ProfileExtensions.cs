using Backlog.Api.Models;

namespace Backlog.Api.Features
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
