using Backlog.SharedKernel;

namespace Backlog.Core;
public static class DigitalAssetExtensions
{
    public static DigitalAssetDto ToDto(this DigitalAsset digitalAsset)
    {
        return new()
        {
            DigitalAssetId = digitalAsset.DigitalAssetId,
            Bytes = digitalAsset.Bytes,
            ContentType = digitalAsset.ContentType,
            Name = digitalAsset.Name,
            Height = digitalAsset.Height,
            Width = digitalAsset.Width
        };
    }

}
}
