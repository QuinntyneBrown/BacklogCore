using Backlog.SharedKernel;

namespace Backlog.Core
{
    public static class TechnologyExtensions
    {
        public static TechnologyDto ToDto(this Technology technology)
        {
            return new()
            {
                TechnologyId = technology.TechnologyId,
                Name = technology.Name,
                Description = technology.Description
            };
        }

    }
}
