using System;

namespace Backlog.Core;
public class ProfileItem
{
    public Guid ProfileItemId { get; private set; }
    public Guid ProfileId { get; private set; }
    public Guid ItemId { get; private set; }

    public ProfileItem(Guid profileId, Guid itemId)
    {
        ProfileId = profileId;
        ItemId = itemId;
    }

    private ProfileItem()
    {

    }
}
}
