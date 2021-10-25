using System;

namespace Backlog.Api.Models
{
    public class DigitalAsset
    {
        public Guid DigitalAssetId { get; set; }
        public string Name { get; set; }
        public byte[] Bytes { get; set; }
        public string ContentType { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
    }
}
