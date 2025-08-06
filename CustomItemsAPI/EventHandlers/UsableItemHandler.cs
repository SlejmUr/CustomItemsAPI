using CustomItemsAPI.Helpers;
using CustomItemsAPI.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace CustomItemsAPI.EventHandlers;

internal sealed class UsableItemHandler : CustomEventsHandler
{
    #region Cancel
    public override void OnPlayerCancellingUsingItem(PlayerCancellingUsingItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.UsableItem, out CustomUsableBase cur_item))
            return;
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        cur_item?.OnCancelling(ev.Player, ev.UsableItem, isAllowed);
        ev.IsAllowed = isAllowed.Value;
    }
    public override void OnPlayerCancelledUsingItem(PlayerCancelledUsingItemEventArgs ev)
    {
        var cur_item = CustomItems.GetCustomItem<CustomUsableBase>(ev.UsableItem);
        cur_item?.OnCancelled(ev.Player, ev.UsableItem);
    }
    #endregion
    #region Use
    public override void OnPlayerUsingItem(PlayerUsingItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.UsableItem, out CustomUsableBase cur_item))
            return;
        TypeWrapper<bool> isAllowed = new(ev.IsAllowed);
        cur_item?.OnUsing(ev.Player, ev.UsableItem, isAllowed);
        ev.IsAllowed = isAllowed.Value;
    }
    public override void OnPlayerUsedItem(PlayerUsedItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.UsableItem, out CustomUsableBase cur_item))
            return;
        cur_item.OnUsed(ev.Player, ev.UsableItem);
    }
    #endregion
}
