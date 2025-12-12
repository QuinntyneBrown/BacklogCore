using System;

namespace Backlog.Core;

public class DigitalAssetDto
{
    public System.Guid DigitalAssetId { get; set; }
    public string Name { get; set; }
    public byte[] Bytes { get; set; }
    public string ContentType { get; set; }
    public float Height { get; set; }
    public float Width { get; set; }
}