using CustomItemsAPI.Helpers;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Items;

public abstract class CustomUsableBase : CustomItemBase
{
    /// <summary>
    /// This <paramref name="player"/> who cancelled using this item.
    /// </summary>
    /// <param name="player">The Player who called this function</param>
    public virtual void OnCancellingUsing(Player player, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who cancelled using this item.
    /// </summary>
    /// <param name="player">The Player who called this function</param>
    public virtual void OnCancellingUsed(Player player)
    {

    }

    public virtual void OnUsing(Player player, TypeWrapper<bool> isAllowed)
    {

    }


    public virtual void OnUsed(Player player)
    {

    }
}
