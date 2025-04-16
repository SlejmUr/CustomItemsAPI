using CustomItemsAPI.Helpers;
using LabApi.Features.Wrappers;

namespace CustomItemsAPI.Items;

public abstract class CustomUsableBase : CustomItemBase
{
    public virtual float UseTime { get; set; } = float.NaN;

    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item is not UsableItem usable)
            throw new ArgumentException("Usable must not be null!");
        if (UseTime != float.NaN)
            usable.Base.UseTime = UseTime;
    }

    /// <summary>
    /// This <paramref name="player"/> who cancelling using this item.
    /// </summary>
    /// <param name="player">The Player who called this function</param>
    /// <param name="isAllowed">Can allow this action</param>
    public virtual void OnCancelling(Player player, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who cancelled using this item.
    /// </summary>
    /// <param name="player">The Player who called this function</param>
    public virtual void OnCancelled(Player player)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who using this item.
    /// </summary>
    /// <param name="player">The Player who called this function</param>
    /// <param name="isAllowed">Can allow this action</param>
    public virtual void OnUsing(Player player, TypeWrapper<bool> isAllowed)
    {

    }

    /// <summary>
    /// This <paramref name="player"/> who used this item.
    /// </summary>
    /// <param name="player">The Player who called this function</param>
    public virtual void OnUsed(Player player)
    {

    }
}
