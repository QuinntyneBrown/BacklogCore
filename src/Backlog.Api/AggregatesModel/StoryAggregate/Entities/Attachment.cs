using Microsoft.EntityFrameworkCore;
using System;

namespace Backlog.Api.Models
{
    [Owned]
    public class Attachment
    {
        public Guid DigitalAssetId { get; set; }
    }
}
