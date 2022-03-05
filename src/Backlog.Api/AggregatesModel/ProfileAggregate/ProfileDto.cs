using System;

namespace Backlog.Api.Features
{
    public class ProfileDto
    {
        public Guid? ProfileId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
