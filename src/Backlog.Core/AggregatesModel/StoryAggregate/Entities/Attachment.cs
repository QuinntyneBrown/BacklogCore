using Microsoft.EntityFrameworkCore;
using System;

namespace Backlog.Core;

[Owned]
public class Attachment
{
    public Guid DigitalAssetId { get; set; }
}
